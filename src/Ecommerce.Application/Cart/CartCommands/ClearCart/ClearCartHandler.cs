using Ecommerce.Domain.AggregateRootes.Carts.Repository;
using Ecommerce.Domain.BaseEntity;
using MediatR;

namespace Ecommerce.Application.Cart.CartCommands.ClearCart;

public class ClearCartHandler(
    ICartRepository cartRepository,
    ICurrentUserService currentUserService)
    : IRequestHandler<ClearCartCommand, ClearCartResponse>
{
    public async Task<ClearCartResponse> Handle(
        ClearCartCommand request,
        CancellationToken cancellationToken)
    {
        var userId = currentUserService.UserId;

        if (userId == null)
        {
            return new ClearCartResponse
            {
                IsSuccess = false,
                Message = "User is not authenticated."
            };
        }

        var cart =cartRepository.GetByUserId(userId.Value);

        if (cart == null)
        {
            return new ClearCartResponse
            {
                IsSuccess = false,
                Message = "Cart Not Found"
            };
        }

        cart.ClearItems();

         cartRepository.ClearCart(cart);

        return new ClearCartResponse
        {
            CartId = cart.Id,
            IsSuccess = true,
            Message = "CartItems Cleared Successfully"
        };
    }
}