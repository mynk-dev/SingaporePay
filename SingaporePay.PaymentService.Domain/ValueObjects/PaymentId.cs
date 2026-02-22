using System;
using System.Collections.Generic;
using System.Text;

namespace SingaporePay.PaymentService.Domain.ValueObjects;
public sealed class PaymentId
{
    public Guid Value { get; }
    private PaymentId(Guid value) {
        if (value == Guid.Empty)
            throw new ArgumentException("PaymentId cannot be empty.");

        Value = value;
    }

    public static PaymentId New()=> new(Guid.NewGuid());

    public static PaymentId FromGuid(Guid guid) => new(guid);

    public override string ToString()=> Value.ToString();
}

