using MediatR;

namespace Ecommerce.Application.Reviews.ReviewCommands.CreateReview;

public class CreateReviewCommand : IRequest<CreateReviewResponse>
{
    public Guid ProductId { get; set; }


    public int Rating { get; set; }

    public string? Comment { get; set; }
}

public class CreateReviewResponse
{
    public string? Message { get; set; }

    public bool IsSuccess { get; set; }
}