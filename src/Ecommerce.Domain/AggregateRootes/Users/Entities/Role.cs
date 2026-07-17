using Ecommerce.Domain.BaseEntity;

namespace Ecommerce.Domain.AggregateRootes.Users.Entities;

public class Role : Base
{
    public string Name { get; set; } = default!;
    public List<UserRoles> UserRoles { get; set; } = [];
    public static Role Create(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException("name");

        return new Role
        {
            Name = name,
            //CreatedDate = DateTime.UtcNow,
            //IsDeleted = false,
            //ModifiedDate = DateTime.UtcNow,
        };
    }
    public void Update(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
       
        Name = name;
        //ModifiedDate = DateTime.Now;
    }
    public void Delete()
    {
        IsDeleted = true;
    }
    public Role CreateRole(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
        return new Role()
        {
            Name = name,
            //CreatedDate = DateTime.Now,
            IsDeleted = false
        };
    }
    public static Role GetAll(string? name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
        return new Role()
        {
            Name = name,

        };
    }
}

