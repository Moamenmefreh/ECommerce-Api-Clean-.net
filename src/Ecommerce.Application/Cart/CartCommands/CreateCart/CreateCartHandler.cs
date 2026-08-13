using Ecommerce.Domain.AggregateRootes.Carts.Entities;
using Ecommerce.Domain.AggregateRootes.Carts.Repository;
using Ecommerce.Domain.AggregateRootes.Users.IRepository;
using Ecommerce.Domain.BaseEntity;
using MediatR;

namespace Ecommerce.Application.Carts.CartCommands.CreateCart;

public class CreateCartHandler(
    ICartRepository cartRepository,
    ICurrentUserService currentUserService)
    : IRequestHandler<CreateCartCommand, CreateCartResponse>
{
    public async Task<CreateCartResponse> Handle(
        CreateCartCommand request,
        CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var userId = currentUserService.UserId;

        if (userId == null)
        {
            return new CreateCartResponse
            {
                IsSuccess = false,
                Message = "User is not authenticated."
            };
        }

        var existingCart = cartRepository.GetByUserId(userId.Value);

        if (existingCart != null)
        {
            return new CreateCartResponse
            {
                IsSuccess = false,
                CartId = existingCart.Id,
                Message = "User already has a cart."
            };
        }

        var cart = Ecommerce.Domain.AggregateRootes.Carts.Entities.Cart.CreateCart(userId.Value);

         cartRepository.AddCart(cart);

        return new CreateCartResponse
        {
            IsSuccess = true,
            CartId = cart.Id,
            Message = "Cart created successfully."
        };
    }
}