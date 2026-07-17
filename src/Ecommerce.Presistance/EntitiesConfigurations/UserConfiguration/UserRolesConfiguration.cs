using Ecommerce.Domain.AggregateRootes.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Presistance.EntitiesConfigurations.UserConfiguration;

public class UserRolesConfiguration : IEntityTypeConfiguration<UserRoles>
{
    public void Configure(EntityTypeBuilder<UserRoles> builder)
    {
        builder.HasKey(x => new
        {
            x.UserId,
            x.RoleId
        });
    }
}

