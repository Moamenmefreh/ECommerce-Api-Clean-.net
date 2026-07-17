using Ecommerce.Domain.AggregateRootes.Products.Entities;
using Ecommerce.Domain.AggregateRootes.Products.Repository;
using MediatR;
using System.Xml.Linq;

namespace Ecommerce.Application.Products.ProductCommands.UpdateProduct;

public class UpdateProductHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
{
    public async Task<UpdateProductResponse> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        Console.WriteLine(request.ProductId);
        var existingProduct = await productRepository.GetById(request.ProductId);
        
        if (existingProduct == null)
        {
            return new UpdateProductResponse
            {
                Product = request.Name,
                Message = "Product Not Found",
                IsSuccess = false
            };
        }

        existingProduct.Update(
            request.Name!,
            request.Description!,
            request.Price,
            request.DiscountPrice,
            request.StockQuantity,
            request.CategoryId,
            request.IsAvailable
        );

        productRepository.UpdateProduct(existingProduct);

        return new UpdateProductResponse
        {
            Product = existingProduct.Name,
            Message = "Product Updated Successfully",
            IsSuccess = true
        };
    }
}

