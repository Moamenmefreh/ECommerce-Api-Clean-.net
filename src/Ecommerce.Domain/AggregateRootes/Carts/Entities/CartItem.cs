using Ecommerce.Domain.AggregateRootes.Carts.Entities;
using Ecommerce.Domain.AggregateRootes.Products.Entities;
using Ecommerce.Domain.BaseEntity;

namespace Ecommerce.Domain.AggregateRootes.Carts.Entities;

public class CartItem:Base
{
    public int Quentity { get; set; } = 1;
  

    public decimal UnitPrice { get; private set; }
    public Cart? Cart { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; } 

  

    public void UpdateQuantity(int quantity)
    {
        Quentity = quantity;
    }
}
