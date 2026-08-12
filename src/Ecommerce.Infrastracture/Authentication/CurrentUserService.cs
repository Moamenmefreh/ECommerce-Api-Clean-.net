using Ecommerce.Domain.BaseEntity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Ecommerce.API.Services;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor)
    : ICurrentUserService
{
    public Guid? UserId
    {
        get
        {
            var userId = httpContextAccessor.HttpContext?
                .User?
                .FindFirst(ClaimTypes.NameIdentifier)?
                .Value;

            if (Guid.TryParse(userId, out var id))
                return id;

            return null;
        }
    }
}