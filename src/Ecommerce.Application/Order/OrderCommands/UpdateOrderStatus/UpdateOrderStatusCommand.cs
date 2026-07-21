using Ecommerce.Domain.AggregateRootes.Orders.Enum;
using MediatR;
using System.Text.Json.Serialization;

namespace Ecommerce.Application.Order.OrderCommands.UpdateOrderStatus;

public class UpdateOrderStatusCommand : IRequest<UpdateOrderStatusResponse>
{
    [JsonIgnore]
    public Guid OrderId { get; set; }

    public OrderStatus Status { get; set; }
}
public class UpdateOrderStatusResponse
{
    public Guid OrderId { get; set; }

    public bool IsSuccess { get; set; }

    public string? Message { get; set; }
}
