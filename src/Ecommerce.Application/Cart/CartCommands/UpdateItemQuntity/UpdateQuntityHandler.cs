using Ecommerce.Domain.AggregateRootes.Carts.Repository;
using MediatR;

namespace Ecommerce.Application.Cart.CartCommands.UpdateItemQuntity;

public class UpdateQuntityHandler(ICartItemRepository cartItemRepository) : IRequestHandler<UpdateQuntityCommands, UpdateQuntityResponse>
{
    public async Task<UpdateQuntityResponse> Handle(UpdateQuntityCommands request, CancellationToken cancellationToken)
    {
        var item=cartItemRepository.GetByItemId(request.ItemId);
        if(item == null)
        {
            throw new ArgumentException(nameof(request));
        }
      
        try
        {
            item.UpdateQuantity(request.Quntity);

            cartItemRepository.UpdateQuntity(item);

            return new UpdateQuntityResponse { ItemId=request.ItemId
            
            ,
            Message="Updated Quntity Successfully",
            IsSuccess=true
            };

        }
        catch (Exception ex) 
        {
            return new UpdateQuntityResponse
            {
                ItemId=request.ItemId,
                Message=ex.Message,
                IsSuccess=false
            };
        }
    }
}
