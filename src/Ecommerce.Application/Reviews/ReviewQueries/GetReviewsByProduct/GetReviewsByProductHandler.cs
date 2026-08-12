using Ecommerce.Domain.AggregateRootes.Reviews.Repository;
using MediatR;

namespace Ecommerce.Application.Reviews.ReviewQueries.GetReviewsByProduct;

public class GetReviewsByProductHandler(
    IReviewRepository reviewRepository)
    : IRequestHandler<GetReviewsByProductQuery, GetReviewsByProductResponse>
{
    public async Task<GetReviewsByProductResponse> Handle(
        GetReviewsByProductQuery request,
        CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        try
        {
            var reviews = await reviewRepository
                .GetByProductId(request.ProductId);

            if (reviews == null || !reviews.Any())
            {
                return new GetReviewsByProductResponse
                {
                    Message = "No Reviews Found For This Product",
                    IsSuccess = true,
                    Reviews = new List<ReviewResponse>()
                };
            }

            return new GetReviewsByProductResponse
            {
                Message = "Reviews Retrieved Successfully",
                IsSuccess = true,
                Reviews = reviews.Select(review => new ReviewResponse
                {
                    Id = review.Id,
                    UserId = review.UserId,
                    ProductId = review.ProductId,
                    Rating = review.Rating,
                    Comment = review.Comment
                }).ToList()
            };
        }
        catch (Exception ex)
        {
            return new GetReviewsByProductResponse
            {
                Message = ex.Message,
                IsSuccess = false
            };
        }
    }
}