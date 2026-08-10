using Ecommerce.Application.Cart.CartCommands.AddItem;
using Ecommerce.Application.Cart.CartCommands.ClearCart;
using Ecommerce.Application.Cart.CartCommands.DeleteItem;
using Ecommerce.Application.Cart.CartCommands.UpdateItemQuntity;
using Ecommerce.Application.Cart.CartQueries.GetCart;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController(ISender sender) : ControllerBase
    {
        [HttpGet("{cartId:guid}")]
        public async Task<IActionResult> GetCart(Guid cartId)
        {
            var result = await sender.Send(new GetCartQuery
            {
                CartId = cartId
            });

            return Ok(result);
        }
        [HttpDelete("{cartId:guid}/clear")]
        public async Task<IActionResult> ClearCart(Guid cartId)
        {
            var result = await sender.Send(new ClearCartCommand
            {
                CartId = cartId
            });

            return Ok(result);
        }
        [HttpDelete("{id:guid}/RemoveItem")]
        public async Task<IActionResult> RemoveItem([FromRoute] Guid id)
        {
            DeleteItemCommands command = new DeleteItemCommands
            {
                ItemId = id
            };
            var result = await sender.Send(command);
            return Ok(result);
        }
        [HttpPost("AddItem")]
        public async Task<IActionResult> CreateItem([FromBody]AddItemCommands command)
        {
            var result = await sender.Send(command);
            return Ok(result);
        }
        
        [HttpPut("{id:guid}")]

        public async Task<IActionResult> UpdateItem([FromRoute]Guid id,UpdateQuntityCommands command)
        {
           command.ItemId = id;
            var result = await sender.Send(command);
            return Ok(result);
        }
    }
}
