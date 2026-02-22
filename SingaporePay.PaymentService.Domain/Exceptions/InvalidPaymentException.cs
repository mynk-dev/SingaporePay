using System;
using System.Collections.Generic;
using System.Text;

namespace SingaporePay.PaymentService.Domain.Exceptions
{
    public sealed class InvalidPaymentException:BaseDomainException
    {
        public InvalidPaymentException(string message) : base(message) { }
        
    }
}
