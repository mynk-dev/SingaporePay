using Microsoft.EntityFrameworkCore;
using SingaporePay.PaymentService.Application.Interfaces;
using SingaporePay.PaymentService.Domain.Entities;
using SingaporePay.PaymentService.Domain.ValueObjects;
using SingaporePay.PaymentService.Infrastructure.Persistence;

namespace SingaporePay.PaymentService.Infrastructure.Repositories;

public sealed class PaymentRepository : IPaymentRepository
{
    private readonly PaymentDbContext _context;

    public PaymentRepository(PaymentDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Payment payment, CancellationToken cancellationToken)
    {
        await _context.Payments.AddAsync(payment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Payment?> GetByIdAsync(PaymentId id, CancellationToken cancellationToken)
    {
        return await _context.Payments
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}