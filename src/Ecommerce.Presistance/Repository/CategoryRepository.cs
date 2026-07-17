using Ecommerce.Domain.AggregateRootes.Products.Entities;
using Ecommerce.Domain.AggregateRootes.Products.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ecommerce.Presistance.Repository;

public class CategoryRepository(AppdbContext dbContext) : ICategoryRepository
{
    public void Add(Category category)
    {
        dbContext.Categories.Add(category);
        dbContext.SaveChanges();
    }

    public void Delete(Category category)
    {
       dbContext.Categories.Remove(category);
        dbContext.SaveChanges();
    }

    public async Task<List<Category>> GetAll(string? name, int pageNumber, int pageSize)
    {
        List<Category> list = dbContext.Categories.ToList();
        if (name != null)
        {
            list = list.Where(x => x.Name.Contains(name)).ToList();
        }
            return list.Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();
        }
    
    public async Task<Category> GetById(Guid id)
    {

        var category= dbContext.Categories.Find(id);
        return category! ;
    }

    public void Update(Category category)
    {
       dbContext.Categories.Update(category);
        dbContext.SaveChanges();
    }
}
