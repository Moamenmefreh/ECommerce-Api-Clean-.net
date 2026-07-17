using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ecommerce.Application;

public static class Class1
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
