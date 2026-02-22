using SingaporePay.PaymentService.Domain.Entities;
using SingaporePay.PaymentService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingaporePay.PaymentService.Domain.Events
{
    public sealed class PaymentFailedEvent:BaseDomainEvent
    {
        public PaymentId PaymentId { get; }
        public string Reason{ get; }
        public PaymentFailedEvent(PaymentId paymentId, string reason)
        {
            PaymentId = paymentId;
            Reason = reason;
        }
    }
}
