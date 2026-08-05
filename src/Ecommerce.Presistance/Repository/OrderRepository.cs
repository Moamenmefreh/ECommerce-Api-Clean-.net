using Ecommerce.Domain.AggregateRootes.Orders.Entities;
using Ecommerce.Domain.AggregateRootes.Orders.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Presistance.Repository;

public class OrderRepository(AppdbContext dbContext) : IOrderRepository
{
    public void Add(Order order)
    {
        dbContext.Orders.Add(order);
        dbContext.SaveChanges();
    }


    public Order? GetById(Guid orderId)
    {
        return dbContext.Orders
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefault(x => x.Id == orderId);
    }


    public List<Order> GetUserOrders(Guid userId)
    {
        return dbContext.Orders
            .Where(x => x.UserId == userId)
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .OrderByDescending(x => x.OrderDate)
            .ToList();
    }


    public void Update(Order order)
    {
        dbContext.Orders.Update(order);
        dbContext.SaveChanges();
    }
}