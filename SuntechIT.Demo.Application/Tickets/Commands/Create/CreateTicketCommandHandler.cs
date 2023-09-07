using Ardalis.GuardClauses;
using Ardalis.Result;
using MediatR;
using SuntechIT.Demo.Domain.Repositories;
using Ardalis.Result.FluentValidation;
using SuntechIT.Demo.Domain.Entities.Tickets;
using SuntechIT.Demo.Domain.Enums;
using SuntechIT.Demo.Application.Tickets.Commands.Create.Validators;

namespace SuntechIT.Demo.Application.Tickets.Commands.Create
{
    internal class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Result>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketCommandHandler(ITicketRepository ticketRepository,
            IProjectRepository projectRepository,
            IUnitOfWork unitOfWork)
        {
            _ticketRepository = Guard.Against.Null(ticketRepository);
            _projectRepository = Guard.Against.Null(projectRepository);
            _unitOfWork = Guard.Against.Null(unitOfWork);
        }

        public async Task<Result> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTicketCommandValidator();

            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return Result.Invalid(result.AsErrors());
            }

            var project = await _projectRepository.GetProjectById(request.ProjectId, cancellationToken);

            if (project is null)
            {
                var validationErrorList = new List<ValidationError>()
                {
                    new ValidationError{ ErrorCode = "400", ErrorMessage = "Invalid project" }
                };

                return Result.Invalid(validationErrorList);
            }

            Ticket ticket = new(request.Name, request.Description, request.ProjectId, request.UserId, TicketStatus.Pending);

            _ticketRepository.Add(ticket);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
