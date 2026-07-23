using Ecommerce.Domain.AggregateRootes.Orders.Repository;
using MediatR;

namespace Ecommerce.Application.Order.OrderCommands.UpdateOrderStatus;

public class UpdateOrderStatusHandler(
IOrderRepository orderRepository)
: IRequestHandler<UpdateOrderStatusCommand, UpdateOrderStatusResponse>
{
public async Task<UpdateOrderStatusResponse> Handle(
    UpdateOrderStatusCommand request,
    CancellationToken cancellationToken)
{
    try
    {
        var order = orderRepository.GetById(request.OrderId);

        if (order == null)
        {
            return new UpdateOrderStatusResponse
            {
                OrderId = request.OrderId,
                IsSuccess = false,
                Message = "Order not found"
            };
        }

        order.UpdateStatus(request.Status);

        orderRepository.Update(order);

        return new UpdateOrderStatusResponse
        {
            OrderId = order.Id,
            IsSuccess = true,
            Message = "Order status updated successfully"
        };
    }
    catch (Exception ex)
    {
        return new UpdateOrderStatusResponse
        {
            OrderId = request.OrderId,
            IsSuccess = false,
            Message = ex.Message
        };
    }
}
}