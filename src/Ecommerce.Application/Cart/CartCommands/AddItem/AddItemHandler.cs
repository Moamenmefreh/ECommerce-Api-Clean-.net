using Ecommerce.Domain.AggregateRootes.Carts.Entities;
using Ecommerce.Domain.AggregateRootes.Carts.Repository;
using MediatR;

namespace Ecommerce.Application.Cart.CartCommands.AddItem;

public class AddItemHandler(ICartItemRepository cartItemRepository) : IRequestHandler<AddItemCommands, AddItemResponse>
{
    public async Task<AddItemResponse> Handle(AddItemCommands request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));

        }
        try
        {
            var cart = cartItemRepository.GetbyCartId(request.CartId);
            if (cart == null)
            {
                return new AddItemResponse
                {
                    ItemId = request.CartId,
                    Message = "Cart Not Found",
                    IsSuccess = false,
                };
            }
            var cartItem=CartItem.CreateItem(request.Quntity,request.Price,request.CartId,request.ProductId);
            cartItemRepository.Add(cartItem);
            return new AddItemResponse
            {
                ItemId= cartItem.Id,
                Message="Add Item Successfully",
                IsSuccess=true,
            };
        }
        catch(Exception ex)
        {
            return new AddItemResponse
            {
                ItemId=Guid.Empty,
                IsSuccess=false,
                Message=ex.Message,
            };
        }
    }
}
