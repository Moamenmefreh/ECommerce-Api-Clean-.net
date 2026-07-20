using Ecommerce.Domain.AggregateRootes.Carts.Repository;
using MediatR;

namespace Ecommerce.Application.Cart.CartQueries.GetCart;

public class GetCartHandler(ICartRepository cartRepository)
    : IRequestHandler<GetCartQuery, GetCartResponse>
{
    public async Task<GetCartResponse> Handle(
        GetCartQuery request,
        CancellationToken cancellationToken)
    {
        var cart = cartRepository.GetCart(request.CartId);

        if (cart == null)
        {
            return new GetCartResponse
            {
                IsSuccess = false,
                Message = "Cart Not Found"
            };
        }

        var response = new GetCartResponse
        {
            CartId = cart.Id,
            IsSuccess = true,
            Message = "Cart Retrieved Successfully"
        };

        foreach (var item in cart.CartItems)
        {
            response.Items.Add(new GetCartResponse.CartItemResponse
            {
                ItemId = item.Id,
                ProductId = item.ProductId,
                ProductName = item.Product?.Name ?? string.Empty,
                Quantity = item.Quentity,
                UnitPrice = item.UnitPrice,
                TotalPrice = item.UnitPrice * item.Quentity
            });
        }

        response.SubTotal = response.Items.Sum(x => x.TotalPrice);

        return response;
    }
}