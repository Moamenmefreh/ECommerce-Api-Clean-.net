using Ecommerce.API.Services;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.JWT;
using Ecommerce.Domain.AggregateRootes.Carts.Repository;
using Ecommerce.Domain.AggregateRootes.Orders.Repository;
using Ecommerce.Domain.AggregateRootes.Products.Repository;
using Ecommerce.Domain.AggregateRootes.Reviews.Repository;
using Ecommerce.Domain.AggregateRootes.Users.IRepository;
using Ecommerce.Domain.BaseEntity;
using Ecommerce.Infrastracture.Authentication;
using Ecommerce.Infrastructure.Authentication;
using Ecommerce.Presistance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace Ecommerce.Presistance;

public static class ServiceCollectionExtensions
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)

    {
        // DbContext
        services.AddDbContext<AppdbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.Configure<EmailSettings>(
            configuration.GetSection("EmailSettings"));

        services.Configure<JwtOptions>(
       configuration.GetSection("Jwt"));

        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddScoped<EmailSettings>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],

                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(
                                    configuration["Jwt:Key"]!))
                    };
            });

        services.AddAuthorization();
    }
}