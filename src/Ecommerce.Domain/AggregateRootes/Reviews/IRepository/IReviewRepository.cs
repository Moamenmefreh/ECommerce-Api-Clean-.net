using Ecommerce.Domain.AggregateRootes.Reviews.Entities;

namespace Ecommerce.Domain.AggregateRootes.Reviews.Repository;

public interface IReviewRepository
{
    public Task<Review> GetById(Guid id);

    public Task<List<Review>> GetByProductId(Guid productId);

    public void AddReview(Review review);

    public void UpdateReview(Review review);

    public void DeleteReview(Guid id);
}