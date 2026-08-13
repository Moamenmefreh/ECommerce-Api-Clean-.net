using Ecommerce.Domain.AggregateRootes.Products.Entities;
using Ecommerce.Domain.BaseEntity;
using MediatR;

namespace Ecommerce.Domain.AggregateRootes.Carts.Entities;

public class CartItem:Base
{
    public int Quentity { get; set; } = 1;
    public decimal UnitPrice { get; private set; }
    public Cart? Cart { get; set; }
    
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    public static CartItem CreateItem(int quantity,Guid productId,Guid cartId)
    {
        return new CartItem
        {
            Id = Guid.NewGuid(),
            Quentity = quantity,
            ProductId = productId,
            CartId = cartId,
            CreatedAt = DateTime.UtcNow
        };
    }
    public void UpdateQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");
        Quentity = quantity;
        
    }
}
