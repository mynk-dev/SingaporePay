using MediatR;
using Microsoft.AspNetCore.Mvc;
using SingaporePay.PaymentService.Application.Commands;

namespace SingaporePay.PaymentService.API.Endpoints;
    public static class CreatePaymentEndpoint
    {
        public static void MapCreatePaymentEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("/payments", async (
                [FromBody] CreatePaymentCommand command, IMediator mediator , CancellationToken ct) =>
                {
                    var paymentId = await mediator.Send(command, ct);
                    return Results.Ok(new { PaymentId = paymentId });
                });
        }
    }