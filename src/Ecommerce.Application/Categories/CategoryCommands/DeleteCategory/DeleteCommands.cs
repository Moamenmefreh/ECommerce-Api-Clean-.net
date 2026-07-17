using MediatR;

namespace Ecommerce.Application.Categories.CategoryCommands.DeleteCategory;

public class DeleteCommands:IRequest<DeleteResponse>
{
    public Guid CategoryId { get; set; }

}
public class DeleteResponse
{
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}
