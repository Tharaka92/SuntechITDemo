using FluentValidation;

namespace SuntechIT.Demo.Application.Tickets.Commands.Create.Validators
{
    internal class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name cannot be null or empty");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Name length cannot exceed 100 characters");

            RuleFor(x => x.ProjectId)
               .GreaterThan(0)
               .WithMessage("Invalid project id");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Description length cannot exceed 500 characters");
        }
    }
}
