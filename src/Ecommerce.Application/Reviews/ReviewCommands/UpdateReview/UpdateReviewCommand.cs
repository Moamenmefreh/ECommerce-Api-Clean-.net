using MediatR;
using System.Text.Json.Serialization;

namespace Ecommerce.Application.Reviews.ReviewCommands.UpdateReview;

public class UpdateReviewCommand : IRequest<UpdateReviewResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }
}

public class UpdateReviewResponse
{
    public string? Message { get; set; }

    public bool IsSuccess { get; set; }
}