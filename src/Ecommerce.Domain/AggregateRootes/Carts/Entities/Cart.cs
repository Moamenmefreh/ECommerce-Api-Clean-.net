using Ecommerce.Domain.AggregateRootes.Users.Entities;
using Ecommerce.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.AggregateRootes.Carts.Entities
{
    public class Cart : Base
    {
      
        public User? User { get; set; }
        public List<CartItem>? CartItems { get; set; }
    }
}