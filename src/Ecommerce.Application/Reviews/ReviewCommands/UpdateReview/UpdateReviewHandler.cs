using Ecommerce.Domain.AggregateRootes.Reviews.Repository;
using MediatR;

namespace Ecommerce.Application.Reviews.ReviewCommands.UpdateReview;

public class UpdateReviewHandler(
    IReviewRepository reviewRepository)
    : IRequestHandler<UpdateReviewCommand, UpdateReviewResponse>
{
    public async Task<UpdateReviewResponse> Handle(
        UpdateReviewCommand request,
        CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        try
        {
            var review = await reviewRepository.GetById(request.Id);

            if (review == null)
            {
                return new UpdateReviewResponse
                {
                    Message = "Review Not Found",
                    IsSuccess = false
                };
            }

            review.Update(
                request.Rating,
                request.Comment);

             reviewRepository.UpdateReview(review);

            return new UpdateReviewResponse
            {
                Message = "Review Updated Successfully",
                IsSuccess = true
            };
        }
        catch (Exception ex)
        {
            return new UpdateReviewResponse
            {
                Message = ex.Message,
                IsSuccess = false
            };
        }
    }
}