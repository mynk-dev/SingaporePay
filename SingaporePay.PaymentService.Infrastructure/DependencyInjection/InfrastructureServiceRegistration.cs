using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SingaporePay.PaymentService.Application.Interfaces;
using SingaporePay.PaymentService.Infrastructure.Persistence;
using SingaporePay.PaymentService.Infrastructure.Repositories;

namespace SingaporePay.PaymentService.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<PaymentDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("Database")));

        services.AddScoped<IPaymentRepository, PaymentRepository>();

        return services;
    }
}