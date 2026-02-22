using System;
using System.Collections.Generic;
using System.Text;

namespace SingaporePay.PaymentService.Domain.ValueObjects;
public sealed class Money
{
    public decimal Amount { get; }
        
    public string Currency { get; }

    private Money(decimal amount, string currency)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentNullException("Currency is required.");

        Amount = decimal.Round(amount, 2, MidpointRounding.ToEven);
        Currency=currency.ToUpperInvariant();
    }

    public static Money Create(decimal amount,string currency)
        => new(amount, currency);

    public static Money Zero(string currency)
        => new(0.01m, currency);

    public override string ToString() => $"{Amount} {Currency}";
}
