using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SingaporePay.PaymentService.Domain.Entities;
using SingaporePay.PaymentService.Domain.ValueObjects;


namespace SingaporePay.PaymentService.Infrastructure.Configurations;

public sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {

        builder.ToTable("Payments");

        builder.HasKey(p => p.Id);

        builder.Ignore(p => p.Events);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PaymentId.FromGuid(value));

        builder.Property(p => p.SenderId)
            .HasConversion(id => id.Value, v => UserId.Create(v));

        builder.Property(p => p.ReceiverId)
            .HasConversion(id => id.Value, v => UserId.Create(v));

        builder.OwnsOne(p => p.Amount, money =>
        {
            money.Property(m => m.Amount)
                 .HasColumnName("Amount")
                 .IsRequired();

            money.Property(m => m.Currency)
                 .HasColumnName("Currency")
                 .HasMaxLength(3)
                 .IsRequired();
        });

        builder.Property(p => p.Status)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(p => p.ReferenceNumber)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.CompletedAt);
    }
}