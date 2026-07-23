using Ecommerce.Domain.AggregateRootes.Orders.Entities;

namespace Ecommerce.Domain.AggregateRootes.Orders.Repository;

public interface IOrderRepository
{
    void Add(Order order);

    Order? GetById(Guid orderId);

    List<Order> GetUserOrders(Guid userId);

    void Update(Order order);
}