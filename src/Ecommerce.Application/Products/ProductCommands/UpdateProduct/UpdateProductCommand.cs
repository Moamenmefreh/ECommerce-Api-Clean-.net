using MediatR;
using System.Text.Json.Serialization;

namespace Ecommerce.Application.Products.ProductCommands.UpdateProduct;

public class UpdateProductCommand:IRequest<UpdateProductResponse>
{
    [JsonIgnore]
    public Guid ProductId { get; set; }
    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public decimal? DiscountPrice { get; set; }

    public int StockQuantity { get; set; }

    public bool IsAvailable { get; set; }

    public Guid CategoryId { get; set; }
}
public class UpdateProductResponse
{
    public string? Product { get; set; }
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}
