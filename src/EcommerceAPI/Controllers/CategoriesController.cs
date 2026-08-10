using Ecommerce.Application.Categories.CategoryCommands.CreateCategory;
using Ecommerce.Application.Categories.CategoryCommands.DeleteCategory;
using Ecommerce.Application.Categories.CategoryCommands.UpdateCategory;
using Ecommerce.Application.Categories.CategoryQueries.GetAll;
using Ecommerce.Application.Categories.CategoryQueries.GetBYId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    // GET: api/Categories
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllQueries query)
    {
        var result = await mediator.Send(query);

        return Ok(result);
    }

    // GET: api/Categories/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetByIdQuery
        {
            CategoryId = id
        };

        var result = await mediator.Send(query);

        return Ok(result);
    }

    // POST: api/Categories
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(
        [FromBody] CreateCategoryCommand command)
    {
        var result = await mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    // PUT: api/Categories/{id}
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateCommands command)
    {
        command.Id = id;

        var result = await mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    // DELETE: api/Categories/{id}
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteCommands
        {
            CategoryId = id
        };

        var result = await mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }
}
