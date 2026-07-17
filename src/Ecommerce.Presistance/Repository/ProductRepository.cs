using Ecommerce.Domain.AggregateRootes.Products.Entities;
using Ecommerce.Domain.AggregateRootes.Products.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Presistance.Repository;

public class ProductRepository(AppdbContext dbcontext) : IProductRepository
{
    public async void AddProduct(Product product)
    {
        dbcontext.Products.Add(product);
        dbcontext.SaveChanges();
    }

    public void DeleteProduct(Guid id)
    {
        var product = dbcontext.Products.SingleOrDefault(p => p.Id == id);
        if (product != null)
        {
            dbcontext.Products.Remove(product);
            dbcontext.SaveChanges();
        }
    }

   
       public async Task<List<Product>> GetAllProduct(
    string? name,
    int pageNumber,
    int pageSize)
    {
        List<Product> query = dbcontext.Products.ToList();

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(x => x.Name.Contains(name)).ToList();
        }

        return  query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
    
    public async Task<Product> GetById(Guid id)
    {
        var product = dbcontext.Products.SingleOrDefault(x => x.Id == id);
      
        return product!;
    }


    public void  UpdateProduct(Product product)
    {
        if (product != null)
        {
             dbcontext.Products.Update(product);
             dbcontext.SaveChanges();


        }
    }
}
