using FluentValidation;

namespace SuntechIT.Demo.Application.Projects.Commands.Create.Validators
{
    internal class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name cannot be null or empty");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Name length cannot exceed 100 characters");

            RuleFor(x => x.CustomerId)
               .GreaterThan(0)
               .WithMessage("Invalid customer id");
        }
    }
}
