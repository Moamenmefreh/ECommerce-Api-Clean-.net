using Ecommerce.Domain.AggregateRootes.Users.Entities;
using Ecommerce.Domain.AggregateRootes.Users.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Presistance.Repository;

public class UserRepository(AppdbContext _context) : IUserRepository
{


    public async Task<User> Create(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }


    public async Task Delete(User user)
    {
        user.IsDeleted = true;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }


    public async Task<List<User>> GetAll(string? name)
    {
        var query = _context.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(x => x.Name.Contains(name));
        }

        return await query.ToListAsync();
    }


    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Email == email);
    }


    public async Task<User?> GetById(Guid id)
    {
        return await _context.Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Id == id);
    }


    public async Task<User?> GetByVerificationTokenAsync(string token)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.VerificationToken == token);
    }


    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }


    public async Task<string> ChangePassword(Guid userId, string newPassword)
    {
        var user = await GetById(userId);

        if (user == null)
            throw new Exception("User not found");

        user.ChangePassword(newPassword);

        await _context.SaveChangesAsync();

        return "Password changed successfully";
    }

    public Task RemoveRoleUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveRoleUser(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<string> ChangePassword(int userId, string newPassword)
    {
        throw new NotImplementedException();
    }
}