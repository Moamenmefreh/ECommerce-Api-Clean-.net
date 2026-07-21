using Ecommerce.Domain.AggregateRootes.Users.Entities;

namespace Ecommerce.Domain.AggregateRootes.Users.Repository;

public interface IUserRepository
{
    Task<User> Create(User user);

    Task Update(User user);

    Task<User?> GetById(Guid id);

    Task Delete(User user);

    Task<List<User>> GetAll(string? name);

    Task RemoveRoleUser(Guid userId);

    Task<User?> GetByEmail(string email);

    Task<User?> GetByVerificationTokenAsync(string token);

    Task<string> ChangePassword(Guid userId, string newPassword);
}