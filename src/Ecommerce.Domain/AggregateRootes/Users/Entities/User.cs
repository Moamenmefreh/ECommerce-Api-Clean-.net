using Ecommerce.Domain.AggregateRootes.Carts.Entities;
using Ecommerce.Domain.AggregateRootes.Orders.Entities;
using Ecommerce.Domain.BaseEntity;
namespace Ecommerce.Domain.AggregateRootes.Users.Entities;

public class User : Base
{
    public string Name { get; set; } = default!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }

    public bool IsActive { get; set; }
    public bool EmailVerified { get; set; }

    public string? VerificationToken { get; set; }

    public DateTime? VerificationTokenExpiry { get; set; }
   

    public string? PasswordResetToken { get; private set; }

    public DateTime? PasswordResetTokenExpiry { get; private set; }
    public Cart? Cart { get; set; }
    public List<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
    //public List<Cart>? Cart {  get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public static User Create(string name, string phone, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password is required");

        if (password.Length < 6)
            throw new ArgumentException("Password must be at least 6 characters");

        if (string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("Phone is required");

        return new User()
        {
            Name = name,
            IsDeleted = false,
           // CreatedDate = DateTime.Now,
          
            Phone = phone,
            PasswordHash = password,
            Email = email
        };
    }
    public void GeneratePasswordResetToken()
    {
        PasswordResetToken = Guid.NewGuid().ToString();

        PasswordResetTokenExpiry = DateTime.UtcNow.AddHours(1);
    }
    public void ResetPassword(string passwordHash)
    {
        PasswordHash = passwordHash;

        PasswordResetToken = null;

        PasswordResetTokenExpiry = null;

        UpdatedAt = DateTime.UtcNow;
    }
    public void Update(string name, string phone)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        if (string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("Phone is required");

        if (phone.Length < 10)
            throw new ArgumentException("Phone must be at least 10 digits");

        Name = name;
        IsActive = true;
        Phone = phone;
       // ModifiedDate = DateTime.UtcNow;
    }
    
    public void Delete(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Invalid user id");

        IsDeleted = true;
    }
    public void ChangePassword(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password is required");

        if (passwordHash.Length < 6)
            throw new ArgumentException("Password must be at least 6 characters");

        PasswordHash = passwordHash;
        UpdatedAt = DateTime.Now;
       // ModifiedDate = DateTime.UtcNow;
    }
    //public void GeneratePasswordResetToken()
    //{
    //    PasswordResetToken = Guid.NewGuid().ToString();
    //    PasswordResetTokenExpiry = DateTime.UtcNow.AddHours(1);
    //}
    public void DeleteRole(int roleId)
    {
        if (roleId <= 0)
            throw new ArgumentException("Invalid role id");

        //var userRole = UserRoles.FirstOrDefault(r => r.UserId == this.Id && r.RoleId == roleId);

        //if (userRole == null)
        //    throw new ArgumentException("User does not have this role");

        //UserRoles.Remove(userRole);
    }

    //public void ResetPassword(string newPassword)
    //{
    //    PasswordHash = newPassword;
    //    PasswordResetToken = null;
    //    PasswordResetTokenExpiry = null;
    //    UpdatedAt = DateTime.UtcNow;
    //}
    //public void AddRole(Guid roleId)
    //{
    //    if (roleId <= 0)
    //        throw new ArgumentException("Invalid role id");

    //    //if (UserRoles.Any(r => r.UserId == this.Id && r.RoleId == roleId))
    //    //    throw new ArgumentException("User already has this role");

    //    UserRoles.Add(new UserRoles
    //    {
    //      //  UserId = this.Id,
    //        RoleId = roleId
    //    });
    //}
}