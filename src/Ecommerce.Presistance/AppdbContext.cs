using Ecommerce.Domain.AggregateRootes.Carts.Entities;
using Ecommerce.Domain.AggregateRootes.Orders.Entities;
using Ecommerce.Domain.AggregateRootes.Products.Entities;
using Ecommerce.Domain.AggregateRootes.Reviews.Entities;
using Ecommerce.Domain.AggregateRootes.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Presistance;

public class AppdbContext: DbContext
{
    public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppdbContext).Assembly);
    }
    public DbSet<Product> Products=>Set<Product>();
    public DbSet<Category> Categories=>Set<Category>();
    public DbSet<Cart> Carts=>Set<Cart>();
    public DbSet<CartItem> CartItems=>Set<CartItem>();
    public DbSet<User>Users=>Set<User>();
    public DbSet<Role> Roles=>Set<Role>();
    public DbSet<UserRoles> UserRoles=>Set<UserRoles>();
    public DbSet<Order> Orders=>Set<Order>();
    public DbSet<OrderItem> OrderItems=>Set<OrderItem>();
    public DbSet<Review> Reviews => Set<Review>();
}
