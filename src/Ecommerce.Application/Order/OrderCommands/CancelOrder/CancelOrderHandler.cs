using Ecommerce.Domain.AggregateRootes.Orders.Repository;
using MediatR;

namespace Ecommerce.Application.Orders.OrderCommands.CancelOrder;

public class CancelOrderHandler(
    IOrderRepository orderRepository)
    : IRequestHandler<CancelOrderCommand, CancelOrderResponse>
{
    public async Task<CancelOrderResponse> Handle(
        CancelOrderCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var order = orderRepository.GetById(request.OrderId);

            if (order == null)
            {
                return new CancelOrderResponse
                {
                    OrderId = request.OrderId,
                    IsSuccess = false,
                    Message = "Order not found"
                };
            }


            order.Cancel();


            orderRepository.Update(order);


            return new CancelOrderResponse
            {
                OrderId = order.Id,
                IsSuccess = true,
                Message = "Order cancelled successfully"
            };
        }
        catch (Exception ex)
        {
            return new CancelOrderResponse
            {
                OrderId = request.OrderId,
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }
}