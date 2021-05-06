using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty();
        }
    }
}
