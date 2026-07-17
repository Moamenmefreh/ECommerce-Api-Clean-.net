using Ecommerce.Domain.AggregateRootes.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Presistance.EntitiesConfigurations.UserConfiguration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50).HasColumnType("NVarChar");

        builder.HasMany(x => x.UserRoles)
           .WithOne(x => x.Role).
           HasForeignKey(x => x.RoleId);
    }
}
