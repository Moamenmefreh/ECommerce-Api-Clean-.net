using Ecommerce.Domain.AggregateRootes.Products.Entities;
using Ecommerce.Domain.BaseEntity;

namespace Ecommerce.Domain.AggregateRootes.Carts.Entities;

public class CartItem:Base
{
    public int Quentity { get; set; } = 1;
    public decimal UnitPrice { get; private set; }
    public Cart? Cart { get; set; }
    
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; } 

    public static CartItem CreateItem(int quntity, decimal price, Guid cartId, Guid productId)
    {
        return new CartItem
        {
            Id = Guid.NewGuid(),
            Quentity = quntity,
            UnitPrice = price,
            CreatedAt = DateTime.UtcNow,
            ProductId = productId,
            CartId = cartId
        };
    }
    public void UpdateQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");
        Quentity = quantity;
        
    }
}
