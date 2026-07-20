using Ecommerce.Domain.AggregateRootes.Carts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Presistance.EntitiesConfigurations.CartConfiguration;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(x=>x.Id);
        builder.HasOne(x => x.Cart)
       .WithMany(c => c.CartItems)
       .HasForeignKey(x => x.CartId)
       .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Quentity)
              .IsRequired();

        builder.Property(x => x.UnitPrice)
               .HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.Product)
               .WithMany()
               .HasForeignKey("ProductId")
               .OnDelete(DeleteBehavior.Restrict);
    }
}
