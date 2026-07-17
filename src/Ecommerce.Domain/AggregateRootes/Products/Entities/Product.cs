namespace Ecommerce.Domain.AggregateRootes.Products.Entities;

using System;
using System.Collections.Generic;
using Ecommerce.Domain.AggregateRootes.Carts.Entities;
using Ecommerce.Domain.BaseEntity;

public class Product : Base
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public decimal? DiscountPrice { get; set; }

    public int StockQuantity { get; set; }

    public bool IsAvailable { get; set; }

    public Guid CategoryId { get; set; }

    public Category? Category { get; set; }

   
    public CartItem? CartItem { get; set; }
    public static Product Create(string name, string description, decimal price, decimal? discountPrice, int quantity, Guid categoryId, bool isAvailable = true)
    {
        return new Product
        {
            Price = price,
            Name = name,
            Description = description,
            DiscountPrice = discountPrice,
            IsAvailable = isAvailable,
            IsDeleted = false,
           
          
            
        };

    }
    public void Delete(Guid productId) { 
       
    }
    public  void Update(string name, string description, decimal price, decimal? discountPrice, int quantity, Guid categoryId, bool isAvailable = true)
    {

        if (name != null)
        {
            Name = name;
            Description = description;
            Price = price;
            DiscountPrice = discountPrice;
            StockQuantity = quantity;
            CategoryId = categoryId;
            IsAvailable = isAvailable;
        }

    }
    public  List<Product> GetAll(string? name)
    {
        return new List<Product>
        {
            new Product
            {
                Id = Id,
                Name = name,
                Description = "Sample description",
                Price = 10.99m,
                DiscountPrice = 9.99m,
                StockQuantity = 100,
                CategoryId = Guid.NewGuid(),
                IsAvailable = true
            }
        };

    }
    //public ICollection<ProductImage> Images { get; set; }

    //public ICollection<Review> Reviews { get; set; }
}
