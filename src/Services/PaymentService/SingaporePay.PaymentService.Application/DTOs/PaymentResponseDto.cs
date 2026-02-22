using System;
using System.Collections.Generic;
using System.Text;

namespace SingaporePay.PaymentService.Application.DTOs
{
    public sealed class PaymentResponseDto
    {
        public Guid PaymentId { get; init; }
        public string Status { get; init; } = default!;
    }
}
