using Ecommerce.Domain.AggregateRootes.Orders.Repository;
using MediatR;

namespace Ecommerce.Application.Orders.OrderQueries.GetUserOrders;

public class GetUserOrdersHandler(
    IOrderRepository orderRepository)
    : IRequestHandler<GetUserOrdersQuery, List<GetUserOrdersResponse>>
{
    public async Task<List<GetUserOrdersResponse>> Handle(
        GetUserOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var orders = orderRepository.GetUserOrders(request.UserId);

        return orders.Select(order => new GetUserOrdersResponse
        {
            OrderId = order.Id,
            TotalPrice = order.TotalPrice,
            Status = order.Status.ToString(),
            OrderDate = order.OrderDate

        }).ToList();
    }
}