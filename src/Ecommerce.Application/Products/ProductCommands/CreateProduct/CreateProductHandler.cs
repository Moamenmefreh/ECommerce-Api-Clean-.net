using Ecommerce.Domain.AggregateRootes.Products.Entities;
using Ecommerce.Domain.AggregateRootes.Products.Repository;
using MediatR;
using System.Xml.Linq;

namespace Ecommerce.Application.Products.ProductCommands.CreateProduct;

public class DeleteProductHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        try
        {
            var newProduct = Product.Create(request.Name!, request.Description!, request.Price, request.DiscountPrice, request.StockQuantity, request.CategoryId, request.IsAvailable = true);


             productRepository.AddProduct(newProduct);



            return new CreateProductResponse
            {
                Product = request.Name,
                Message = "Product Created Successfully",
                IsSuccess = true,

            };
        }
        catch (Exception ex)
        {
            return new CreateProductResponse
            {
                Product = request.Name,
                Message = ex.Message,
                IsSuccess = false
            };
        }
}
}

