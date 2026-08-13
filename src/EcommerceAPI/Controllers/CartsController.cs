using Ecommerce.Application.Cart.CartCommands.AddItem;
using Ecommerce.Application.Cart.CartCommands.ClearCart;
using Ecommerce.Application.Cart.CartCommands.DeleteItem;
using Ecommerce.Application.Cart.CartCommands.UpdateItemQuntity;
using Ecommerce.Application.Cart.CartQueries.GetCart;
using Ecommerce.Application.Carts.CartCommands.CreateCart;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartsController(ISender sender) : ControllerBase
    {
        [HttpGet("Get Cart")]
        public async Task<IActionResult> GetCart()
        {
            var result = await sender.Send(new GetCartQuery());

            return Ok(result);
        }
        [HttpDelete("/clearItems")]
        public async Task<IActionResult> ClearCart()
        {
            var result = await sender.Send(new ClearCartCommand());

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
        public async Task<IActionResult> CreateItem([FromBody]AddItemCommand command)
        {
            var result = await sender.Send(command);
            return Ok(result);
        }
        [HttpPost("CreateCart")]
        public async Task<IActionResult> CreateCart()
        {
            var result = await sender.Send(new CreateCartCommand());
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
