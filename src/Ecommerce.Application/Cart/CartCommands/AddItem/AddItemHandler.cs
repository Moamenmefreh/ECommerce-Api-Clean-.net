using Ecommerce.Domain.AggregateRootes.Carts.Entities;
using Ecommerce.Domain.AggregateRootes.Carts.Repository;
using Ecommerce.Domain.BaseEntity;
using MediatR;

namespace Ecommerce.Application.Cart.CartCommands.AddItem;

public class AddItemHandler(
    ICartRepository cartRepository,
    ICartItemRepository cartItemRepository,
    ICurrentUserService currentUserService)
    : IRequestHandler<AddItemCommand, AddItemResponse>
{
    public async Task<AddItemResponse> Handle(
        AddItemCommand request,
        CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        try
        {
            // Get UserId from JWT Token
            var userId = currentUserService.UserId;

            if (userId == null)
            {
                return new AddItemResponse
                {
                    IsSuccess = false,
                    Message = "User is not authenticated."
                };
            }

            // Get user's cart
            var cart = cartRepository.GetByUserId(userId.Value);

            if (cart == null)
            {
                return new AddItemResponse
                {
                    IsSuccess = false,
                    Message = "Cart not found."
                };
            }

            // Create CartItem
            var cartItem = CartItem.CreateItem(request.Quantity,request.ProductId,cart.Id);

             cartItemRepository.Add(cartItem);

            return new AddItemResponse
            {
                ItemId = cartItem.Id,
                Message = "Item added successfully.",
                IsSuccess = true
            };
        }
        catch (Exception ex)
        {
            return new AddItemResponse
            {
                ItemId = Guid.Empty,
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }
}