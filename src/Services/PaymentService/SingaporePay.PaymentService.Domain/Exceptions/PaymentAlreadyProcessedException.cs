using System;
using System.Collections.Generic;
using System.Text;

namespace SingaporePay.PaymentService.Domain.Exceptions
{
    public sealed class PaymentAlreadyProcessedException:BaseDomainException
    {
        public PaymentAlreadyProcessedException():base("Payment has already been completed.") { }
    }
}
