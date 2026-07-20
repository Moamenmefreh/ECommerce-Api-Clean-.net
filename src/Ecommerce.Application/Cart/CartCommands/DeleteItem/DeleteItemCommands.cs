using Ecommerce.Application.Categories.CategoryCommands.DeleteCategory;
using MediatR;

namespace Ecommerce.Application.Cart.CartCommands.DeleteItem;

public class DeleteItemCommands:IRequest<DeleteItemResponse>
{
    public Guid ItemId { get; set; }
}
public class DeleteItemResponse
{
    public Guid ItemId {  get; set; }
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}