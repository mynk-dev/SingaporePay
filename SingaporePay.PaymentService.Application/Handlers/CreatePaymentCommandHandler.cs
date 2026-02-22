using MediatR;
using SingaporePay.PaymentService.Application.Commands;
using SingaporePay.PaymentService.Application.Interfaces;
using SingaporePay.PaymentService.Domain.Entities;
using SingaporePay.PaymentService.Domain.ValueObjects;

namespace SingaporePay.PaymentService.Application.Handlers;

public sealed class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Guid>
{
    private readonly IPaymentRepository _paymentRepository;

    public CreatePaymentCommandHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }
    public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = Payment.Create(UserId.Create(request.SenderId), UserId.Create(request.ReceiverId), Money.Create(request.Amount, request.Currency), request.ReferenceNumber);

        await _paymentRepository.AddAsync(payment, cancellationToken);

        return payment.Id.Value;
    }
}