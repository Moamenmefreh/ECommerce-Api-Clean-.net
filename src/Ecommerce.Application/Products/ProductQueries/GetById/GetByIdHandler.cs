using Ecommerce.Domain.AggregateRootes.Products.Repository;
using MediatR;

namespace Ecommerce.Application.Products.ProductQueries.GetById;

public class GetByIdHandler(IProductRepository productRepository) : IRequestHandler<GetByIdQuery, GetByIdResponse>
{
    public async Task<GetByIdResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        if(request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        try
        {
            var product=await productRepository.GetById(request.ProductId);
            if (product != null)
            {
                return new GetByIdResponse
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quntity=product.StockQuantity
                };
            }
            return null!;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message, nameof(request));
        }
    }
}
