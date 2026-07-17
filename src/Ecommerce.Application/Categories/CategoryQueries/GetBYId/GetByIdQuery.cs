using MediatR;

namespace Ecommerce.Application.Categories.CategoryQueries.GetBYId;

public class GetByIdQuery:IRequest<GetByIdResponse>
{
    public Guid CategoryId { get; set; }
}
public class GetByIdResponse
{
    public Guid CategoryId { get; set; }
    public string? NameCategory { get; set; }
    public string? Description {  get; set; }
}