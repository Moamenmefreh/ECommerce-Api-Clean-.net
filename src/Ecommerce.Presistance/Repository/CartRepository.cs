using Ecommerce.Domain.AggregateRootes.Carts.Entities;
using Ecommerce.Domain.AggregateRootes.Carts.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Presistance.Repository;

public class CartRepository(AppdbContext dbContext):ICartRepository
{
    public Cart? GetCart(Guid cartId)
    {
        return dbContext.Carts
              .Include(c => c.CartItems)
              .ThenInclude(i => i.Product)
              .FirstOrDefault(c => c.Id == cartId);
    }
    public void ClearCart(Cart cart)
    {
        dbContext.CartItems.RemoveRange(cart.CartItems);
        dbContext.SaveChanges();
    }
    public Cart? GetByUserId(Guid userId)
    {
        return dbContext.Carts
            .Include(c => c.CartItems)
            .ThenInclude(i => i.Product)
            .FirstOrDefault(c => c.UserId == userId);
    }
}
