using MediatR;

namespace Ecommerce.Application.Cart.CartCommands.AddItem;

public class AddItemCommand : IRequest<AddItemResponse>
{
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
}

public class AddItemResponse
{
    public Guid ItemId { get; set; }
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}