using SingaporePay.PaymentService.Domain.Enums;
using SingaporePay.PaymentService.Domain.Events;
using SingaporePay.PaymentService.Domain.Exceptions;
using SingaporePay.PaymentService.Domain.ValueObjects;

namespace SingaporePay.PaymentService.Domain.Entities;

public sealed class Payment
{
    private readonly List<BaseDomainEvent> _events = new();
    public IReadOnlyCollection<BaseDomainEvent> Events => _events;

    public PaymentId Id { get; private set; }
    public UserId SenderId { get; private set; }
    public UserId ReceiverId { get; private set; }
    public Money Amount { get; private set; }
    public PaymentStatus Status { get; private set; }
    public string ReferenceNumber { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    private Payment() { }

    private Payment(
        PaymentId id,
        UserId senderId,
        UserId receiverId,
        Money amount,
        string referenceNumber)
    {
        if (senderId == receiverId)
            throw new InvalidPaymentException("Sender and receiver cannot be same.");

        Id = id;
        SenderId = senderId;
        ReceiverId = receiverId;
        Amount = amount;
        ReferenceNumber = referenceNumber;
        Status = PaymentStatus.Initiated;
        CreatedAt = DateTime.UtcNow;

        _events.Add(new PaymentCreatedEvent(Id, SenderId, ReceiverId, Amount.Amount));
    }

    public static Payment Create(
        UserId senderId,
        UserId receiverId,
        Money amount,
        string referenceNumber)
    {
        return new Payment(
            PaymentId.New(),
            senderId,
            receiverId,
            amount,
            referenceNumber);
    }

    public void MarkProcessing()
    {
        EnsureNotCompleted();
        Status = PaymentStatus.Processing;
    }

    public void MarkSucceeded()
    {
        EnsureNotCompleted();
        Status = PaymentStatus.Succeeded;
        CompletedAt = DateTime.UtcNow;

        _events.Add(new PaymentSucceededEvent(Id));
    }

    public void MarkFailed()
    {
        EnsureNotCompleted();
        Status = PaymentStatus.Failed;
        CompletedAt = DateTime.UtcNow;

        _events.Add(new PaymentFailedEvent(Id, "Payment failed."));
    }

    public void MarkTimedOut()
    {
        EnsureNotCompleted();
        Status = PaymentStatus.TimedOut;
        CompletedAt = DateTime.UtcNow;
    }

    private void EnsureNotCompleted()
    {
        if (Status is PaymentStatus.Succeeded or PaymentStatus.Failed)
            throw new PaymentAlreadyProcessedException();
    }
    public void ClearEvents() => _events.Clear();
}