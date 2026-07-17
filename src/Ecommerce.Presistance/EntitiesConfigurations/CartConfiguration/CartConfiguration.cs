using Ecommerce.Domain.AggregateRootes.Carts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Presistance.EntitiesConfigurations.CartConfiguration;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {


        builder.HasOne(x => x.User)
           .WithOne()
           .HasForeignKey<Cart>("UserId");

        builder.HasMany(x => x.CartItems)
               .WithOne()
               .HasForeignKey("CartId")
               .OnDelete(DeleteBehavior.Restrict);

    }
}
