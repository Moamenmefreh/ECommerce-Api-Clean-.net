using MediatR;

namespace Ecommerce.Application.Categories.CategoryCommands.CreateCategory;

public class CreateCategoryCommand:IRequest<CreateCategoryResponse> {

    public string name { get; set; } = default!;
    public string? description { get; set; }
    public string? imageUrl {  get; set; }
}

public class CreateCategoryResponse
{
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}