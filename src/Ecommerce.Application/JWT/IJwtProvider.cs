using Ecommerce.Domain.AggregateRootes.Users.Entities;

namespace Ecommerce.Application.JWT;

using Ecommerce.Domain.AggregateRootes.Users.Entities;

public interface IJwtProvider
{
    string GenerateToken(User user, List<string> roles);
}