using Ecommerce.Domain.AggregateRootes.Carts.Repository;
using MediatR;

namespace Ecommerce.Application.Cart.CartCommands.ClearCart;

public class ClearCartHandler(ICartRepository cartRepository)
    : IRequestHandler<ClearCartCommand, ClearCartResponse>
{
    public async Task<ClearCartResponse> Handle(
        ClearCartCommand request,
        CancellationToken cancellationToken)
    {
        var cart = cartRepository.GetCart(request.CartId);

        if (cart == null)
        {
            return new ClearCartResponse
            {
                CartId = request.CartId,
                IsSuccess = false,
                Message = "Cart Not Found"
            };
        }
        cart.ClearItems();
        cartRepository.ClearCart(cart);

        return new ClearCartResponse
        {
            CartId = request.CartId,
            IsSuccess = true,
            Message = "CartItems Cleared Successfully"
        };
    }
}