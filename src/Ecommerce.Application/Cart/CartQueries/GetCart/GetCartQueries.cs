using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Cart.CartQueries.GetCart;

public class GetCartQuery : IRequest<GetCartResponse>
{
}
public class GetCartResponse
{
    public Guid CartId { get; set; }

    public List<CartItemResponse> Items { get; set; } = [];

    public decimal SubTotal { get; set; }

    public bool IsSuccess { get; set; }

    public string? Message { get; set; }

    public class CartItemResponse
    {
        public Guid ItemId { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }



}
