using Ecommerce.Domain.AggregateRootes.Users.Entities;
using Ecommerce.Domain.BaseEntity;

namespace Ecommerce.Domain.AggregateRootes.Carts.Entities;

public class Cart : Base
{

    public Guid UserId { get; set; }
    public User? User { get; set; }
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public static Cart CreateCart(Guid userId)
    {
       
        return new Cart
        {
            Id = Guid.NewGuid(),
            UserId = userId

        };
    }

    public void ClearItems()
    {
        CartItems.Clear();
    }
}