using FluentValidation;

namespace SuntechIT.Demo.Application.Customers.Commands.Create.Validators
{
    internal class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name cannot be null or empty");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Name length cannot exceed 100 characters");
        }
    }
}
