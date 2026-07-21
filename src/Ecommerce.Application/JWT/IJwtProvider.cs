using Ecommerce.Domain.AggregateRootes.Users.Entities;

namespace Ecommerce.Application.JWT;

public interface IJwtProvider
{
    string GenerateToken(User user, List<string> roles);
}