using Ecommerce.Domain.AggregateRootes.Carts.Entities;

namespace Ecommerce.Domain.AggregateRootes.Carts.Repository;

public interface ICartRepository
{
    public Cart? GetCart(Guid cartId);
    public void ClearCart(Cart cart);
    Cart? GetByUserId(Guid userId);
}
