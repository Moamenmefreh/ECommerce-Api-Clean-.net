using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController(ISender sender) : ControllerBase
{
    //[HttpPut("{orderId:guid}/status")]
    //public async Task<IActionResult> UpdateStatus([FromRoute]Guid orderId,[FromBody] UpdateOrderStatusCommand command)
    //{
    //    command.OrderId = orderId;

    //    var result = await sender.Send(command);

    //    return Ok(result);
    //}
}
