//using Ecommerce.Application.Features.Reviews.Commands.CreateReview;
//using Ecommerce.Application.Features.Reviews.Commands.DeleteUserReviews;
//using Ecommerce.Application.Features.Reviews.Commands.UpdateReview;
//using Ecommerce.Application.Features.Reviews.Queries.GetProductReviews;
using Ecommerce.Application.Reviews.ReviewCommands.CreateReview;
using Ecommerce.Application.Reviews.ReviewCommands.DeleteReview;
using Ecommerce.Application.Reviews.ReviewCommands.UpdateReview;
using Ecommerce.Application.Reviews.ReviewQueries.GetReviewsByProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ReviewsController (ISender sender): ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Create(CreateReviewCommand command)
    {
        var result = await sender.Send(command);
        return Ok(result);
    }


    [HttpGet("/api/products/reviews")]
    public async Task<IActionResult> GetProductReviews([FromQuery] Guid productId)
    {
        var query = new GetReviewsByProductQuery
        {
            ProductId = productId
        };
        var result = await sender.Send(query);

        return Ok(result);
    }
    [HttpPut("{id}")]

    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateReviewCommand command)
    {
        command.Id = id;

        var result = await sender.Send(command);

        return Ok(result);
    }
    [HttpDelete("my-reviews/{id:guid}")]
    public async Task<IActionResult> DeleteMyReviews([FromRoute] Guid id)
    {
        var command = new DeleteReviewCommand
        {
            Id=id
        };
        var result = await sender.Send(command);

        return Ok(result);
    }
}