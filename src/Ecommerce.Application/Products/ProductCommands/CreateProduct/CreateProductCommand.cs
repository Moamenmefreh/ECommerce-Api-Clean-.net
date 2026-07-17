using MediatR;

namespace Ecommerce.Application.Products.ProductCommands.CreateProduct;

public class CreateProductCommand:IRequest<CreateProductResponse>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public decimal? DiscountPrice { get; set; }

    public int StockQuantity { get; set; }

    public bool IsAvailable { get; set; }

    public Guid CategoryId { get; set; }
}
public class CreateProductResponse
{
    public string? Product { get; set; }
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}
