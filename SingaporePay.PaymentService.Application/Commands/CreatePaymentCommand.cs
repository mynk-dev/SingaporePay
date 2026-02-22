using MediatR;

namespace SingaporePay.PaymentService.Application.Commands;
public sealed record CreatePaymentCommand(Guid SenderId, Guid ReceiverId, decimal Amount, string Currency, string ReferenceNumber) : IRequest<Guid>;
