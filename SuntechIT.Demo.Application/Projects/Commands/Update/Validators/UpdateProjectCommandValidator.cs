using FluentValidation;

namespace SuntechIT.Demo.Application.Projects.Commands.Update.Validators
{
    internal class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name cannot be null or empty");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Name length cannot exceed 100 characters");

            RuleFor(x => x.Id)
               .GreaterThan(0)
               .WithMessage("Invalid project id");
        }
    }
}
