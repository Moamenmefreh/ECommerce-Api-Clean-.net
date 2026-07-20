using MediatR;

namespace Ecommerce.Application.Cart.CartCommands.ClearCart;

public class ClearCartCommand : IRequest<ClearCartResponse>
{
    public Guid CartId { get; set; }
}
public class ClearCartResponse
{
    public Guid CartId { get; set; }

    public bool IsSuccess { get; set; }

    public string? Message { get; set; }
}