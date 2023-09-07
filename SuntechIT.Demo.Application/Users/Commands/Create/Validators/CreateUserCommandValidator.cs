using FluentValidation;

namespace SuntechIT.Demo.Application.Users.Commands.Create.Validators
{
    internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email cannot be null or empty");

            RuleFor(x => x.Email)
               .EmailAddress()
               .WithMessage("Invalid email address");

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Password cannot be null or empty");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(10);

            RuleFor(x => x.Role)
                .IsInEnum()
                .WithMessage("Invalid role.");
        }
    }
}
