using Ecommerce.Application.Cart.CartCommands.UpdateItemQuntity;
using Ecommerce.Domain.AggregateRootes.Carts.Entities;
using Ecommerce.Domain.AggregateRootes.Carts.Repository;

namespace Ecommerce.Presistance.Repository;

public class CartItemRepository(AppdbContext dbContext) : ICartItemRepository
{
    //int quntity, decimal price, Guid cartId, Guid productId
    public void Add(CartItem cartItem)
    {
        dbContext.CartItems.Add(cartItem);
        dbContext.SaveChanges();
    }

    public void DeleteItem(CartItem cartItem)
    {
        dbContext.CartItems.Remove(cartItem);
        dbContext.SaveChanges();
    }

    public Cart GetbyCartId(Guid cartId)
    {
      var cart = dbContext.Carts.FirstOrDefault(x=>x.Id == cartId);
        if (cart == null)
        {
            return null!;
        }
        return cart;
    }

    public CartItem GetByItemId(Guid cartId) {
        var cartItem = dbContext.CartItems.FirstOrDefault(x => x.Id == cartId);
        if (cartItem == null)
        {
            return null!;
        }
        return cartItem;
    }

   
    public void UpdateQuntity(CartItem item)
    {
        dbContext.CartItems.Update(item);
            dbContext.SaveChanges();
    }
}
