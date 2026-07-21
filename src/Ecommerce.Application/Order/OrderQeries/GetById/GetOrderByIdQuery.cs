using MediatR;

namespace Ecommerce.Application.Orders.OrderQueries.GetOrderById;

public class GetOrderByIdQuery : IRequest<GetOrderResponse>
{
    public Guid OrderId { get; set; }
}
public class GetOrderResponse
{
    public Guid OrderId { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public List<OrderItemResponse> Items { get; set; } = [];



    public class OrderItemResponse
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total { get; set; }
    }
}