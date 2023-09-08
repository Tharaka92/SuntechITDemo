using FluentValidation;

namespace SuntechIT.Demo.Application.Projects.Commands.Assign.Validators
{
    internal class AssignProjectCommandValidator : AbstractValidator<AssignProjectCommand>
    {
        public AssignProjectCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty()
                .WithMessage("UserId cannot be null or empty");

            RuleFor(x => x.ProjectId)
               .GreaterThan(0)
               .WithMessage("Invalid project id");
        }
    }
}
