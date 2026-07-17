using MediatR;

namespace Ecommerce.Application.Categories.CategoryQueries.GetAll;

public class GetAllQueries:IRequest<List<GetAllResponse>>
{
    public string? CategoryName { get; set; }
    public int pageNumber { get; set; }

    public int pageSize { get; set;  }
}
public class GetAllResponse
{
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedDate { get; set; }
}