using MediatR;

namespace Ecommerce.Application.Reviews.ReviewQueries.GetReviewsByProduct;

public class GetReviewsByProductQuery : IRequest<GetReviewsByProductResponse>
{
    public Guid ProductId { get; set; }
}

public class GetReviewsByProductResponse
{
    public string? Message { get; set; }

    public bool IsSuccess { get; set; }

    public List<ReviewResponse> Reviews { get; set; } = new();
}

public class ReviewResponse
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }
}