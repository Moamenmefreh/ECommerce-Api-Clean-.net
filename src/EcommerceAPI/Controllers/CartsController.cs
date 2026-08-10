using Ecommerce.Application.Cart.CartCommands.AddItem;
using Ecommerce.Application.Cart.CartCommands.ClearCart;
using Ecommerce.Application.Cart.CartCommands.DeleteItem;
using Ecommerce.Application.Cart.CartCommands.UpdateItemQuntity;
using Ecommerce.Application.Cart.CartQueries.GetCart;
using Ecommerce.Application.Products.ProductQueries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartsController(ISender sender) : ControllerBase
{
   

    // GET: api/Carts/{cartId}
    [HttpGet("{cartId:guid}")]
    public async Task<IActionResult> GetCart(Guid cartId)
    {
        var query=new GetCartQuery
        {
            CartId = cartId
        };
        var result = await sender.Send(query);
            
        return Ok(result);
    }

    // POST: api/Carts/AddItem
    [HttpPost("AddItem")]
    public async Task<IActionResult> AddItem(
        [FromBody] AddItemCommands command)
    {
        var result = await sender.Send(command);

        return Ok(result);
    }

    // PUT: api/Carts/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateItem(
        Guid id,
        [FromBody] UpdateQuntityCommands command)

    {
        command.ItemId = id;
        var result = await sender.Send(command);

        return Ok(result);
    }

    // DELETE: api/Carts/{id}/RemoveItem
    [HttpDelete("{id:guid}/RemoveItem")]
    public async Task<IActionResult> RemoveItem(Guid id)
    {
        var comand = new DeleteItemCommands
        {
            ItemId = id
        };
        var result = await sender.Send(comand);

        return Ok(result);
    }

    // DELETE: api/Carts/{cartId}/clear
    [HttpDelete("{cartId:guid}/clear")]
    public async Task<IActionResult> ClearCart(Guid cartId)
    {
        var query = new GetCartQuery
        {
            CartId = cartId
        };
        var result = await sender.Send(cartId);

        return Ok(result);
    }
}