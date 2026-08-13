using MediatR;

namespace Ecommerce.Application.Carts.CartCommands.CreateCart;

public class CreateCartCommand : IRequest<CreateCartResponse>
{
}

public class CreateCartResponse
{
    public Guid CartId { get; set; }
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}