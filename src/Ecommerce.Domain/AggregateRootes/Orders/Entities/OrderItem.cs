using Ecommerce.Domain.AggregateRootes.Orders.Entities;
using Ecommerce.Domain.AggregateRootes.Products.Entities;
using Ecommerce.Domain.BaseEntity;

public class OrderItem : Base
{
    public Guid OrderId { get; set; }
    public Order? Order { get; set; }

    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    public int Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    public static OrderItem Create(
        Guid orderId,
        Guid productId,
        int quantity,
        decimal unitPrice)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        return new OrderItem
        {
            Id = Guid.NewGuid(),
            OrderId = orderId,
            ProductId = productId,
            Quantity = quantity,
            UnitPrice = unitPrice,
            CreatedAt = DateTime.UtcNow
        };
    }
}