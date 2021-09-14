using FluentValidation;

namespace ECommerce.Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandValidator:AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("{Email} is required.").NotNull().MaximumLength(50)
                .WithMessage("{Email} must not exceed 50 characters.");
            RuleFor(x => x.TotalPrice).NotEmpty().WithMessage("{TotalPrice} is required.")
                .GreaterThan(0).WithMessage("Total price should be greater than zero.");
        }
    }
}