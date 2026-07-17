using Ecommerce.Domain.AggregateRootes.Products.Repository;
using MediatR;

namespace Ecommerce.Application.Products.ProductQueries.GetAll;

public class GetAllHandler(IProductRepository productRepository) : IRequestHandler<GetAllQueries, List<GetAllQueriesResponse>>
{
    public async Task<List<GetAllQueriesResponse>> Handle(GetAllQueries request, CancellationToken cancellationToken)
    {

        var products = await productRepository.GetAllProduct(
      request.ProductName,
      request.PageNumber,
      request.PageSize);


        return products.Select(p => new GetAllQueriesResponse
        {
            ProductId = p.Id,
            NameProduct = p.Name
        }).ToList();
    }
    }
