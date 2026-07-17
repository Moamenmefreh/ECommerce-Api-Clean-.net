using MediatR;
using System.Text.Json.Serialization;

namespace Ecommerce.Application.Categories.CategoryCommands.UpdateCategory;

public class UpdateCommands:IRequest<UpdateResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }
}
public class UpdateResponse
{
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}