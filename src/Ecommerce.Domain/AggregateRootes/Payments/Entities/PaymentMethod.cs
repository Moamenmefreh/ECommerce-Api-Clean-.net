using Ecommerce.Domain.BaseEntity;

namespace Ecommerce.Domain.AggregateRootes.Payments.Entities;

public class PaymentMethod : Base
{
    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public static PaymentMethod Create(string name, string? description)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        return new PaymentMethod { Name = name, Description = description };
    }

    public void Update(string name, string? description, bool isActive)
    {
        Name = name;
        Description = description;
        IsActive = isActive;
        UpdatedAt = DateTime.UtcNow;
    }
}
