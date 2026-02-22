using FluentValidation;
using MediatR;
using Microsoft.OpenApi;
using SingaporePay.PaymentService.API.Endpoints;
using SingaporePay.PaymentService.API.Middleware;
using SingaporePay.PaymentService.Application.Behaviors;
using SingaporePay.PaymentService.Application.Commands;
using SingaporePay.PaymentService.Application.Validators;
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

// Validation pipe line 
builder.Services.AddValidatorsFromAssemblyContaining<CreatePaymentCommandValidator>();

builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));

var app = builder.Build();

app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCreatePaymentEndpoint();

app.Run();