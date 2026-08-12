namespace Ecommerce.Domain.BaseEntity;

public interface ICurrentUserService
{
   public Guid? UserId { get; }
}
