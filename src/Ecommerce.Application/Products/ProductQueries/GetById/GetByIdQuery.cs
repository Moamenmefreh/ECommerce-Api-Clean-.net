using MediatR;

namespace Ecommerce.Application.Products.ProductQueries.GetById;

public class GetByIdQuery:IRequest<GetByIdResponse>
{
    public Guid ProductId { get; set; }
}
public class GetByIdResponse
{
   public Guid ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Quntity { get; set; }
}
