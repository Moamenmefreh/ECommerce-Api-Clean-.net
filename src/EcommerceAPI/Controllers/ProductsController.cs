using Ecommerce.Application.Products.ProductCommands.CreateProduct;
using Ecommerce.Application.Products.ProductCommands.DeleteProduct;
using Ecommerce.Application.Products.ProductCommands.UpdateProduct;
using Ecommerce.Application.Products.ProductQueries.GetAll;
using Ecommerce.Application.Products.ProductQueries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] CreateProductCommand command)
    {
        var result = await sender.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
    {
        DeleteProductCommand command = new DeleteProductCommand { ProductId = id };

        var result = await sender.Send(command);
        return Ok(result);
    }
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductCommand command)
    {
        command.ProductId = id;
        var result = await sender.Send(command);
        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllProducts([FromQuery] string? name, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllQueries
        {
            ProductName = name,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await sender.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]

    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdQuery command=new GetByIdQuery { ProductId = id };
        var result = await sender.Send(command);
        return Ok(result);
    }
}