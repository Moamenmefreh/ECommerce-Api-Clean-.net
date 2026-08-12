using MediatR;

namespace Ecommerce.Application.Reviews.ReviewCommands.DeleteReview;

public class DeleteReviewCommand : IRequest<DeleteReviewResponse>
{
    public Guid Id { get; set; }
}

public class DeleteReviewResponse
{
    public string? Message { get; set; }

    public bool IsSuccess { get; set; }
}