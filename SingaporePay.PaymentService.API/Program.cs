using Microsoft.OpenApi;
using SingaporePay.PaymentService.API.Endpoints;
using SingaporePay.PaymentService.Application.Commands;
using SingaporePay.PaymentService.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreatePaymentCommand).Assembly));

builder.Services.AddSwaggerGen(g =>
{
    g.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SingaporePay",
        Version = "v1",
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCreatePaymentEndpoint();

app.Run();