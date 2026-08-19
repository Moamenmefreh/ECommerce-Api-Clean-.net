using Ecommerce.Domain.AggregateRootes.Orders.Repository;
using Ecommerce.Domain.BaseEntity;
using MediatR;

namespace Ecommerce.Application.Orders.OrderQueries.GetUserOrders;

public class GetUserOrdersHandler(
    IOrderRepository orderRepository,
    ICurrentUserService currentUserService)
    : IRequestHandler<GetUserOrdersQuery, List<GetUserOrdersResponse>>
{
    public async Task<List<GetUserOrdersResponse>> Handle(
        GetUserOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var currentUserId = currentUserService.UserId;

        if (currentUserId == null)
            throw new UnauthorizedAccessException("User is not authenticated.");

        //if (currentUserId.Value != null)
        //    throw new UnauthorizedAccessException(
        //        "You are not allowed to access these orders.");

        var orders = orderRepository.GetUserOrders(currentUserId.Value);
        try {

            return orders.Select(order => new GetUserOrdersResponse
            {
                OrderId = order.Id,
                TotalPrice = order.TotalPrice,
                Status = order.Status.ToString(),
                OrderDate = order.OrderDate

            }).ToList();
        }
        catch(Exception ex)
        {
            throw new Exception($"An error occurred while retrieving user orders: {ex.Message}", ex);
        }
} 


}