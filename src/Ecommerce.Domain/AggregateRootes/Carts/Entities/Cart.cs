using Ecommerce.Domain.AggregateRootes.Users.Entities;
using Ecommerce.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.AggregateRootes.Carts.Entities
{
    public class Cart : Base
    {

        public Guid UserId { get; set; }
        public User? User { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();


        public void ClearItems()
        {
            CartItems.Clear();
        }
    }
}