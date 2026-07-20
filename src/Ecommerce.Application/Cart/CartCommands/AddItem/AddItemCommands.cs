using MediatR;

namespace Ecommerce.Application.Cart.CartCommands.AddItem;

public class AddItemCommands:IRequest<AddItemResponse>
{
    public int Quntity { get; set; }
    public decimal Price { get; set; }
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public DateTime CreateAt { get; set; }

}
public class AddItemResponse
{
    public Guid ItemId { get; set; }
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}