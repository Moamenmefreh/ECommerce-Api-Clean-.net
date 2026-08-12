using Ecommerce.Domain.AggregateRootes.Products.Entities;
using Ecommerce.Domain.AggregateRootes.Users.Entities;
using Ecommerce.Domain.BaseEntity;

namespace Ecommerce.Domain.AggregateRootes.Reviews.Entities;

public class Review : Base
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public static Review Create(
        Guid productId,
        Guid userId,
        int rating,
        string? comment)
    {
        return new Review
        {
            ProductId = productId,
            UserId = userId,
            Rating = rating,
            Comment = comment,
            IsDeleted = false
        };
    }

    public void Update(int rating, string? comment)
    {
        Rating = rating;
        Comment = comment;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }
}