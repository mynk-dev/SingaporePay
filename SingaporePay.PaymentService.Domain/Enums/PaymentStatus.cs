namespace SingaporePay.PaymentService.Domain.Enums;

public enum PaymentStatus
{
    Initiated = 1,
    Processing = 2,
    Succeeded = 3,
    Failed = 4,
    TimedOut = 5,
    Reversed = 6
}