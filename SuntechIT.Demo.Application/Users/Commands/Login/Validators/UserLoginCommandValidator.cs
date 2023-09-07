using FluentValidation;

namespace SuntechIT.Demo.Application.Users.Commands.Login.Validators
{
    internal class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
    {
        public UserLoginCommandValidator()
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
        }
    }
}
