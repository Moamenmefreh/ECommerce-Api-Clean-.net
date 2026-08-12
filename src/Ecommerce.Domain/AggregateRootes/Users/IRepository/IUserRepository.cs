using Ecommerce.Domain.AggregateRootes.Users.Entities;

namespace Ecommerce.Domain.AggregateRootes.Users.Repository;

public interface IUserRepository
{
    public Task<User> Create(User user);
    public Task Update(User user);
    public Task<User> GetById(Guid id);
    public Task Delete(User user);
    public Task<List<User>> GetAll(string? Name);
    //public Task AddRoleToUser(int userId, Role role);
    public void RemoveRoleUser(Guid userId, Guid roleId);
    public Task<User> GetByEmail(string email);
    public Task<User> GetByVerificationTokenAsync(string token);
    public Task<string> ChangePassword(User user);
    Task<User?> GetByPasswordResetToken(string token);
}
