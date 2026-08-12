using Ecommerce.Domain.AggregateRootes.Reviews.Repository;
using Ecommerce.Domain.BaseEntity;
using MediatR;

namespace Ecommerce.Application.Reviews.ReviewCommands.DeleteReview;

public class DeleteReviewHandler(
    IReviewRepository reviewRepository,
    ICurrentUserService currentUserService)
    : IRequestHandler<DeleteReviewCommand, DeleteReviewResponse>
{
    public async Task<DeleteReviewResponse> Handle(
        DeleteReviewCommand request,
        CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        try
        {
            // Get UserId from JWT Token
            var userId = currentUserService.UserId;

            if (userId == null)
            {
                return new DeleteReviewResponse
                {
                    Message = "User is not authenticated",
                    IsSuccess = false
                };
            }

            // Get Review by Review Id
            var review = await reviewRepository.GetById(request.Id);

            if (review == null)
            {
                return new DeleteReviewResponse
                {
                    Message = "Review Not Found",
                    IsSuccess = false
                };
            }

            // Make sure the review belongs to the logged-in user
            if (review.UserId != userId.Value)
            {
                return new DeleteReviewResponse
                {
                    Message = "You are not allowed to delete this review",
                    IsSuccess = false
                };
            }

            // Delete review
            reviewRepository.DeleteReview(request.Id);

            return new DeleteReviewResponse
            {
                Message = "Review Deleted Successfully",
                IsSuccess = true
            };
        }
        catch (Exception ex)
        {
            return new DeleteReviewResponse
            {
                Message = ex.Message,
                IsSuccess = false
            };
        }
    }
}