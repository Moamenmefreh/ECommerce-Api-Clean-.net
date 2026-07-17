using Ecommerce.Domain.AggregateRootes.Products.Entities;
using MediatR;

namespace Ecommerce.Application.Products.ProductQueries.GetAll;

public class GetAllQueries:IRequest<List<GetAllQueriesResponse>>
{
    public string? ProductName { get; set; }
   public int PageNumber { get; set; }
   public int PageSize {  get; set; }
}
public class GetAllQueriesResponse
{
    public Guid ProductId { get; set; }
    public string? NameProduct { get; set; }
}
