using MediatR;

namespace Ecommerce.Application.Orders.OrderCommands.CancelOrder;

public class CancelOrderCommand : IRequest<CancelOrderResponse>
{
    public Guid OrderId { get; set; }
}

public class CancelOrderResponse
{
    public Guid OrderId { get; set; }

    public bool IsSuccess { get; set; }

    public string? Message { get; set; }
}