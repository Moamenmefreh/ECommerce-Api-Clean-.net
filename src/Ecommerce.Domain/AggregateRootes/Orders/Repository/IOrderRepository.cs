using Ecommerce.Domain.AggregateRootes.Orders.Entities;

namespace Ecommerce.Domain.AggregateRootes.Orders.Repository;

public interface IOrderRepository
{
    public void Add(Order order);
}
