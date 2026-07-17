using Ecommerce.Domain.AggregateRootes.Products.Repository;
using Ecommerce.Presistance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace Ecommerce.Presistance;

public static class ServiceCollectionExtensions
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppdbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssembly(
                Assembly.GetExecutingAssembly());
        });
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
}

