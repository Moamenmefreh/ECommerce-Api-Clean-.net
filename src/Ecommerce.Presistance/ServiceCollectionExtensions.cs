using Ecommerce.Application.JWT;
using Ecommerce.Domain.AggregateRootes.Carts.Repository;
using Ecommerce.Domain.AggregateRootes.Orders.Repository;
using Ecommerce.Domain.AggregateRootes.Products.Repository;
using Ecommerce.Domain.AggregateRootes.Users.Repository;
using Ecommerce.Infrastracture.Authentication;
using Ecommerce.Presistance.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ecommerce.Application.JWT;
namespace Ecommerce.Presistance;

public static class ServiceCollectionExtensions
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext
        services.AddDbContext<AppdbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        // Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJwtProvider, JwtProvider>();

        // JWT Options
        services.Configure<JwtOptions>(
            configuration.GetSection("Jwt"));

        // JWT Provider

        // Read JWT settings
        var jwt = configuration
            .GetSection("Jwt")
            .Get<JwtOptions>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
  .AddJwtBearer(options =>
  {
      var jwt = configuration
          .GetSection("Jwt")
          .Get<JwtOptions>();

      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,

          ValidIssuer = jwt!.Issuer,
          ValidAudience = jwt.Audience,

          IssuerSigningKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(jwt.Key))
      };
  });

        // Authorization
        services.AddAuthorization();
    }
}