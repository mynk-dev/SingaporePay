using SingaporePay.PaymentService.Domain.ValueObjects;

namespace SingaporePay.PaymentService.Domain.Events;
public sealed class PaymentSucceededEvent:BaseDomainEvent
{
    public PaymentId PaymentId { get; }
    public PaymentSucceededEvent(PaymentId paymentId)
    {
        PaymentId = paymentId;
    }

}

