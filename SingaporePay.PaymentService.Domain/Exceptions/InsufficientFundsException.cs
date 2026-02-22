using System;
using System.Collections.Generic;
using System.Text;

namespace SingaporePay.PaymentService.Domain.Exceptions
{
    public class InsufficientFundsException:BaseDomainException
    {
        protected InsufficientFundsException() : base("Insufficient funds for this transaction.") { }
    }
}
