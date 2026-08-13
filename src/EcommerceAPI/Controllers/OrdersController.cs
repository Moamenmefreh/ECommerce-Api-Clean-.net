using Ecommerce.Application.Order.OrderCommands.CreateOrder;
using Ecommerce.Application.Orders.OrderCommands.CancelOrder;
using Ecommerce.Application.Orders.OrderQueries.GetOrderById;
using Ecommerce.Application.Orders.OrderQueries.GetUserOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Ecommerce.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await sender.Send(command);
            return Ok(result);
        }
        [HttpPut("{id:guid}/cancel")]
        public async Task<IActionResult> CancelOrder([FromRoute] Guid id)
        {
            CancelOrderCommand command = new CancelOrderCommand { OrderId = id };
            var result = await sender.Send(command);

            return Ok(result);
        }
        [HttpGet("GetOrder")]
        public async Task<IActionResult> GetOrder()
        {
            
            var result = await sender.Send(new GetOrderByIdQuery());
            return Ok(result);
        }
        [HttpGet("oreder user")]
        public async Task<IActionResult> GetUserOrders()
        {
            var result = await sender.Send(new GetUserOrdersQuery());
            
            return Ok(result);

        }
    }
}