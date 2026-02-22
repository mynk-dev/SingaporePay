using System;
using System.Collections.Generic;
using System.Text;

namespace SingaporePay.PaymentService.Domain.Exceptions
{
    public abstract class BaseDomainException:Exception
    {
        protected BaseDomainException(string message):base(message) { }
    }
}
