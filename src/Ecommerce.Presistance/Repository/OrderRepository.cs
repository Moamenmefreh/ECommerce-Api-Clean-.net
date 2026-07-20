using Ecommerce.Domain.AggregateRootes.Orders.Entities;
using Ecommerce.Domain.AggregateRootes.Orders.Repository;

namespace Ecommerce.Presistance.Repository;

public class OrderRepository(AppdbContext dbContext):IOrderRepository
{
    public void Add(Order order)
    {
        dbContext.Orders.Add(order);
        dbContext.SaveChanges();
    }
}
