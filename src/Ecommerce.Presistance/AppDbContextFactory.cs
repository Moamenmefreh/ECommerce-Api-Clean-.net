using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Presistance;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppdbContext>
{
    public AppdbContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();

        //var configuration = new ConfigurationBuilder()
        //    .SetBasePath(basePath)
        //    .AddJsonFile("appsettings.json")
        //    .Build();

        var optionsBuilder = new DbContextOptionsBuilder<AppdbContext>();

        var connectionString = "data source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ecommerce12;Integrated Security=True;Trust Server Certificate=True;";

        optionsBuilder.UseSqlServer(connectionString);

        return new AppdbContext(optionsBuilder.Options);
    }
}