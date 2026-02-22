namespace SingaporePay.PaymentService.Domain.Events;
public abstract class BaseDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}
