using MediatR;

namespace Ecommerce.Application.Orders.OrderQueries.GetUserOrders;

public class GetUserOrdersQuery : IRequest<List<GetUserOrdersResponse>>
{
    public Guid UserId { get; set; }
}
public class GetUserOrdersResponse
{
    public Guid OrderId { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }
}