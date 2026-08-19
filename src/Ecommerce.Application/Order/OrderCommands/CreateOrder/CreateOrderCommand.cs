using MediatR;

namespace Ecommerce.Application.Order.OrderCommands.CreateOrder;

public class CreateOrderCommand : IRequest<CreateOrderResponse>
{
}
public class CreateOrderResponse
{
    public Guid OrderId { get; set; }

    public bool IsSuccess { get; set; }

    public string? Message { get; set; }
}