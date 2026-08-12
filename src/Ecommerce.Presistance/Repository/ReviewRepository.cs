using Ecommerce.Domain.AggregateRootes.Reviews.Entities;
using Ecommerce.Domain.AggregateRootes.Reviews.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Presistance.Repository;

public class ReviewRepository(AppdbContext dbcontext) : IReviewRepository
{
    public async void AddReview(Review review)
    {
        dbcontext.Reviews.Add(review);
        dbcontext.SaveChanges();
    }

    public void DeleteReview(Guid id)
    {
        var review = dbcontext.Reviews.SingleOrDefault(r => r.Id == id);

        if (review != null)
        {
            dbcontext.Reviews.Remove(review);
            dbcontext.SaveChanges();
        }
    }

    public async Task<List<Review>> GetByProductId(Guid productId)
    {
        return await dbcontext.Reviews
            .Where(r => r.ProductId == productId)
            .ToListAsync();
    }

    public async Task<Review> GetById(Guid id)
    {
        var review = dbcontext.Reviews
            .SingleOrDefault(r => r.Id == id);

        return review!;
    }

    public void UpdateReview(Review review)
    {
        if (review != null)
        {
            dbcontext.Reviews.Update(review);
            dbcontext.SaveChanges();
        }
    }
}