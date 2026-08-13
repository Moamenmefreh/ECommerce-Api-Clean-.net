using Ecommerce.Application.Payments.PaymentCommands.CreatePayment;
using Ecommerce.Application.Payments.PaymentCommands.DeletePayment;
using Ecommerce.Application.Payments.PaymentCommands.UpdatePayment;
using Ecommerce.Application.Payments.PaymentQueries.GetAll;
using Ecommerce.Application.Payments.PaymentQueries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController(IMediator mediator) : ControllerBase
{
    // GET: api/payments
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllPaymentsQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    // GET: api/payments/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetPaymentByIdQuery { Id = id };
        var result = await mediator.Send(query);
        if (result == null) return NotFound();
        return Ok(result);
    }

    // POST: api/payments
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CreatePaymentCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    // PUT: api/payments/{id}
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePaymentCommand command)
    {
        command.Id = id;
        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    // DELETE: api/payments/{id}
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeletePaymentCommand { Id = id };
        var result = await mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }
}
