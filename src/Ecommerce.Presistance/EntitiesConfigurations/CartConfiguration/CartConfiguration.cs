using Ecommerce.Domain.AggregateRootes.Carts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Presistance.EntitiesConfigurations.CartConfiguration;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {

        builder.HasKey(x => x.Id);
        builder.HasOne(c => c.User)
       .WithOne(u => u.Cart)
       .HasForeignKey<Cart>(c => c.UserId)
       .OnDelete(DeleteBehavior.Cascade);



    }
}
