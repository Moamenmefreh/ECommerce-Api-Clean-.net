using Ecommerce.Application.Products.ProductCommands.CreateProduct;
using Ecommerce.Application.Products.ProductCommands.DeleteProduct;
using Ecommerce.Domain.AggregateRootes.Products.Entities;
using Ecommerce.Domain.AggregateRootes.Products.Repository;
using MediatR;
using System.Xml.Linq;

namespace Ecommerce.Application.Products.ProductCommands.DeleteProduct;

public class DeleteProductHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
{
    public async Task<DeleteProductResponse> Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        try
        {
          //  var newProduct = Product.(Guid id);


             productRepository.DeleteProduct(request.ProductId);



            return new DeleteProductResponse
            {
                    Product = $"The Product id : {request.ProductId}  is deleted" ,
                Message = "Product Created Successfully",
                IsSuccess = true,

            };
        }
        catch (Exception ex)
        {
            return new DeleteProductResponse
            {
                Product = ex.Message,
                Message = ex.Message,
                IsSuccess = false
            };
        }
}
}

