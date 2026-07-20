using Ecommerce.Domain.AggregateRootes.Carts.Repository;
using Ecommerce.Domain.AggregateRootes.Products.Repository;
using MediatR;

namespace Ecommerce.Application.Cart.CartCommands.DeleteItem;

public class DeleteItemHandler(ICartItemRepository cartItemRepository) : IRequestHandler<DeleteItemCommands, DeleteItemResponse>
{
    public async Task<DeleteItemResponse> Handle(DeleteItemCommands request, CancellationToken cancellationToken)
    {
        if(request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        try
        {
            var cartItem = cartItemRepository.GetByItemId(request.ItemId);
            if (cartItem == null)
            {
                throw new ArgumentException();
            }
            cartItemRepository.DeleteItem(cartItem);
            return new DeleteItemResponse
            {
                ItemId = request.ItemId,
                Message = "Deleted Is Successfully",
                IsSuccess = true,
            };
        }
        catch (Exception ex)
        {
            return new DeleteItemResponse { ItemId = request.ItemId, Message = ex.Message };
        }
    }
}
