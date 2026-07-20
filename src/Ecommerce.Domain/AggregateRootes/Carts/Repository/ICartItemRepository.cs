using Ecommerce.Domain.AggregateRootes.Carts.Entities;

namespace Ecommerce.Domain.AggregateRootes.Carts.Repository;

public interface ICartItemRepository
{
    public void Add(CartItem cartItem);
    public Cart GetbyCartId(Guid cartId);
    public void DeleteItem(CartItem cartItem);
    public CartItem GetByItemId(Guid cartId);
    public void UpdateQuntity(CartItem cartItem);
    
}
