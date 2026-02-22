using SingaporePay.PaymentService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingaporePay.PaymentService.Domain.Events
{
    public sealed class PaymentCreatedEvent:BaseDomainEvent
    {
        public PaymentId PaymentId { get; }
        public UserId SenderId { get; }
        public UserId ReceiverId {  get; }
        public Decimal Amount {  get; }

        public PaymentCreatedEvent(PaymentId paymentId, UserId senderId, UserId receiverId,decimal amount)
        {
            PaymentId = paymentId;
            SenderId = senderId;
            ReceiverId = receiverId;
            Amount = amount;
        }
    }
}
