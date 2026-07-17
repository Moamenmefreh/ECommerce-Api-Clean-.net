using Ecommerce.Domain.AggregateRootes.Products.Entities;

namespace Ecommerce.Domain.AggregateRootes.Products.Repository;

public interface IProductRepository
{
   public Task<Product> GetById(Guid id);
    public Task<List<Product>> GetAllProduct(string? name,int pageNumber,int pageSize);
    public void  AddProduct(Product product);
    public void UpdateProduct(Product product);
    public void DeleteProduct(Guid id);
    //public int MyProperty { get; set; }

}
