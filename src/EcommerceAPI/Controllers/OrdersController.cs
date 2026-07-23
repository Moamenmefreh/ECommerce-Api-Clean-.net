using Ecommerce.Application.Orders.OrderCommands.CancelOrder;
using Ecommerce.Application.Orders.OrderCommands.CreateOrder;
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
        [HttpGet("GetOrder/{id:guid}")]
        public async Task<IActionResult> GetOrder([FromRoute] Guid id)
        {
            GetOrderByIdQuery query = new GetOrderByIdQuery
            {
                OrderId = id,
            };
            var result = await sender.Send(query);
            return Ok(result);
        }
        [HttpGet("user/{userId:guid}")]
        public async Task<IActionResult> GetUserOrders(Guid userId)
        {
            var result = await sender.Send(new GetUserOrdersQuery
            {
                UserId = userId
            });

            return Ok(result);

        }
    }
}