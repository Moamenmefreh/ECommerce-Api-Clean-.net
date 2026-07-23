using Ecommerce.Application.Categories.CategoryCommands.CreateCategory;
using Ecommerce.Application.Categories.CategoryCommands.DeleteCategory;
using Ecommerce.Application.Categories.CategoryCommands.UpdateCategory;
using Ecommerce.Application.Categories.CategoryQueries.GetAll;
using Ecommerce.Application.Categories.CategoryQueries.GetBYId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ISender sender) : ControllerBase
    {
       
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await sender.Send(command);
            return Ok(result);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdQuery query = new GetByIdQuery
            {
                CategoryId = id
            };
            var result = await sender.Send(query);
            return Ok(result);
        }
        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery] string? name, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            GetAllQueries command=new GetAllQueries { CategoryName = name ,
            pageNumber = pageNumber , pageSize = pageSize
            };
            var result = await sender.Send(command);
            return Ok(result);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCommands command)
        {
            command.Id= id;
            var result = await sender.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteCommands command=new DeleteCommands { CategoryId = id };
            var resualt = await sender.Send(command);
            return Ok(resualt);

        }
    }
}
