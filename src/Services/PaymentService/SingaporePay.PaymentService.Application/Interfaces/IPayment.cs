using SingaporePay.PaymentService.Domain.Entities;
using SingaporePay.PaymentService.Domain.ValueObjects;

namespace SingaporePay.PaymentService.Application.Interfaces;
public interface IPaymentRepository
{
    Task AddAsync(Payment payment, CancellationToken cancellationToken);
    Task<Payment?> GetByIdAsync(PaymentId paymentId,CancellationToken cancellationToken);
}
