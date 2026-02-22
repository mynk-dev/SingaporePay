using System;
using System.Collections.Generic;
using System.Text;

namespace SingaporePay.PaymentService.Domain.ValueObjects;
public sealed class UserId
{
    public Guid Value { get; }
    private UserId(Guid value)
    {
        if (value == Guid.Empty) 
            throw new ArgumentNullException("UserId cannot be empty.");

        Value = value;
    }
    public static UserId Create(Guid value)=> new (value);

    public override string ToString()=> Value.ToString();
}