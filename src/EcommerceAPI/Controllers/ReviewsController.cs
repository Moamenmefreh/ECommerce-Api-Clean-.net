//using Ecommerce.Application.Features.Reviews.Commands.CreateReview;
//using Ecommerce.Application.Features.Reviews.Commands.DeleteUserReviews;
//using Ecommerce.Application.Features.Reviews.Commands.UpdateReview;
//using Ecommerce.Application.Features.Reviews.Queries.GetProductReviews;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ReviewsController (ISender sender): ControllerBase
{

    //[HttpPost]
    //public async Task<IActionResult> Create(CreateReviewCommand command)
    //{
    //    var result = await sender.Send(command);
    //    return Ok(result);
    //}


    //[HttpGet("/api/products/{productId}/reviews")]
    //public async Task<IActionResult> GetProductReviews([FromQuery] Guid productId)
    //{
    //    var query = new GetProductReviewsQuery
    //    {
    //        ProductId = productId
    //    };
    //    var result = await sender.Send(query);
          
    //    return Ok(result);
    //}
    //[HttpPut("{id}")]
   
    //public async Task<IActionResult> Update([FromRoute]Guid id,[FromBody]UpdateReviewCommand command)
    //{
    //    command.Id = id;

    //    var result = await sender.Send(command);

    //    return Ok(result);
    //}
    //[HttpDelete("my-reviews")]
    //public async Task<IActionResult> DeleteMyReviews()
    //{
    //    var result = await sender.Send(new DeleteUserReviewsCommand());

    //    return Ok(result);
    //}
}