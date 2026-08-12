using Ecommerce.Domain.AggregateRootes.Reviews.Entities;
using Ecommerce.Domain.AggregateRootes.Reviews.Repository;
using Ecommerce.Domain.BaseEntity;
using MediatR;

namespace Ecommerce.Application.Reviews.ReviewCommands.CreateReview;

public class CreateReviewHandler(
    IReviewRepository reviewRepository,
    ICurrentUserService currentUserService)
    : IRequestHandler<CreateReviewCommand, CreateReviewResponse>
{
    public async Task<CreateReviewResponse> Handle(
        CreateReviewCommand request,
        CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        try
        {
            var userId = currentUserService.UserId;

            if (userId == null)
            {
                return new CreateReviewResponse
                {
                    Message = "User is not authenticated",
                    IsSuccess = false
                };
            }

            var newReview = Review.Create(
                request.ProductId,
                userId.Value,
                request.Rating,
                request.Comment);

            reviewRepository.AddReview(newReview);

            return new CreateReviewResponse
            {
                Message = "Review Created Successfully",
                IsSuccess = true
            };
        }
        catch (Exception ex)
        {
            return new CreateReviewResponse
            {
                Message = ex.Message,
                IsSuccess = false
            };
        }
    }
}