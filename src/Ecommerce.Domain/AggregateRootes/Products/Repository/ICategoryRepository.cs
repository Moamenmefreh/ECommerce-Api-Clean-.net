using Ecommerce.Domain.AggregateRootes.Products.Entities;

namespace Ecommerce.Domain.AggregateRootes.Products.Repository;

public interface ICategoryRepository
{
   public Task<Category> GetById(Guid id);

   public Task<List<Category>> GetAll(string? name, int pageNumber, int pageSize);

    public void Add(Category category);

    public void Update(Category category);

    public void Delete(Category category);

}
