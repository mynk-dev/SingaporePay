using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SingaporePay.PaymentService.Infrastructure.Persistence;

public class PaymentDbContextFactory : IDesignTimeDbContextFactory<PaymentDbContext>
{
    public PaymentDbContext CreateDbContext(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{environment}.json", true)
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<PaymentDbContext>();

        var connectionString =
            configuration.GetConnectionString("Database")
            ?? throw new InvalidOperationException("Connection string 'Default' not found.");

        optionsBuilder.UseSqlServer(connectionString);

        return new PaymentDbContext(optionsBuilder.Options);
    }
}