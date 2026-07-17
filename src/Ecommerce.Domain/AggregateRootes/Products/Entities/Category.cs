using Ecommerce.Domain.BaseEntity;
using Ecommerce.Domain.AggregateRootes.Products.Entities;

namespace Ecommerce.Domain.AggregateRootes.Products.Entities;

public class Category : Base
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public ICollection<Product>? Products { get; set; }

    public static Category Create(string name,string description, string imageUrl)
    {
     if(name == null) throw new ArgumentNullException("name");   
     return new Category() { Name = name, Description = description, ImageUrl = imageUrl };

    }

    public void Update(string name, string description,string imageUrl)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        UpdatedAt = DateTime.UtcNow;
    }
  
}