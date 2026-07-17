using Ecommerce.Application.Products.ProductCommands.CreateProduct;
using MediatR;

namespace Ecommerce.Application.Products.ProductCommands.DeleteProduct;

public class DeleteProductCommand:IRequest<DeleteProductResponse>
{
   public Guid ProductId {  get; set; }
}
public class DeleteProductResponse
{
    public string? Product { get; set; }
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}
