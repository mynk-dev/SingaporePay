using FluentValidation;
using SingaporePay.PaymentService.Application.Commands;

namespace SingaporePay.PaymentService.Application.Validators;
public sealed class CreatePaymentCommandValidator
    : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(x => x.SenderId).NotEmpty();
        RuleFor(x => x.ReceiverId).NotEmpty();
        RuleFor(x => x.ReferenceNumber).NotEmpty();

        RuleFor(x => x.Amount)
            .GreaterThan(0);

        RuleFor(x => x.Currency)
            .NotEmpty()
            .Length(3);
    }
}