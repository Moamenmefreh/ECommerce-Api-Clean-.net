using Ecommerce.Domain.AggregateRootes.Orders.Repository;
using MediatR;

namespace Ecommerce.Application.Orders.OrderQueries.GetOrderById;

public class GetOrderByIdHandler(
    IOrderRepository orderRepository)
    : IRequestHandler<GetOrderByIdQuery, GetOrderResponse>
{
    public async Task<GetOrderResponse> Handle(
        GetOrderByIdQuery request,
        CancellationToken cancellationToken)
    {
        var order = orderRepository.GetById(request.OrderId);

        if (order == null)
        {
            throw new ArgumentException("Order not found");
        }


        var response = new GetOrderResponse
        {
            OrderId = order.Id,
            TotalPrice = order.TotalPrice,
            Status = order.Status.ToString(),
            OrderDate = order.OrderDate
        };


        foreach (var item in order.Items)
        {
            response.Items.Add(new GetOrderResponse.OrderItemResponse
            {
                ProductId = item.ProductId,
                ProductName = item.Product?.Name ?? "",
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                Total = item.UnitPrice * item.Quantity
            });
        }


        return response;
    }
}