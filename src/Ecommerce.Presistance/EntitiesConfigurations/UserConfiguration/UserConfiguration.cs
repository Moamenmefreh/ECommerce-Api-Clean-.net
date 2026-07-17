using Ecommerce.Domain.AggregateRootes.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Presistance.EntitiesConfigurations.UserConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100).HasColumnType("NVarChar");
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100).HasColumnType("NVarChar");

        builder.HasMany(d => d.UserRoles)
              .WithOne(x => x.User)
              .HasForeignKey(x => x.UserId);    
    }
}
