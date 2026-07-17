using System.Text.Json.Serialization;

namespace Ecommerce.Domain.AggregateRootes.Users.Entities;

public class UserRoles
{
    public Guid UserId { get; set; }
    [JsonIgnore]
    public User? User { get; set; }
    public Guid RoleId { get; set; }
    [JsonIgnore]
    public Role?    Role { get; set; }
}
