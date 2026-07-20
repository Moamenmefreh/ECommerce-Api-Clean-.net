using Ecommerce.Domain.AggregateRootes.Orders.Enum;
using Ecommerce.Domain.AggregateRootes.Users.Entities;
using Ecommerce.Domain.BaseEntity;

namespace Ecommerce.Domain.AggregateRootes.Orders.Entities;

public class Order:Base
{
    public Guid UserId { get; set; }

    public User? User { get; set; }

    public decimal TotalPrice { get; private set; }

    public DateTime OrderDate { get; private set; }= DateTime.Now;

    public OrderStatus Status { get; private set; }

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    public static Order Create(Guid userId)
    {
        return new Order
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            OrderDate = DateTime.UtcNow,
            Status = OrderStatus.Pending,
            CreatedAt=DateTime.UtcNow,
        };
    }
    public void AddItem(Guid productId, int quantity, decimal unitPrice)
    {
        var item = OrderItem.Create(
            Id,
            productId,
            quantity,
            unitPrice);

        Items.Add(item);

        CalculateTotal();
    }

    private void CalculateTotal()
    {
        TotalPrice = Items.Sum(x => x.UnitPrice * x.Quantity);
    }

    public void MarkAsPaid()
    {
        Status = OrderStatus.Paid;
    }

    public void Cancel()
    {
        Status = OrderStatus.Cancelled;
    }

}
