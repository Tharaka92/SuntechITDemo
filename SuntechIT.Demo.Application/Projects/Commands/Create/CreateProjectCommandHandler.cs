using Ardalis.GuardClauses;
using Ardalis.Result;
using MediatR;
using SuntechIT.Demo.Domain.Repositories;
using SuntechIT.Demo.Application.Projects.Commands.Create.Validators;
using Ardalis.Result.FluentValidation;
using SuntechIT.Demo.Domain.Entities.Projects;

namespace SuntechIT.Demo.Application.Projects.Commands.Create
{
    internal sealed class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Result>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProjectCommandHandler(IProjectRepository projectRepository,
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            _projectRepository = Guard.Against.Null(projectRepository);
            _customerRepository = Guard.Against.Null(customerRepository);
            _unitOfWork = Guard.Against.Null(unitOfWork);
        }

        public async Task<Result> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProjectCommandValidator();

            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return Result.Invalid(result.AsErrors());
            }

            var customer = await _customerRepository.GetCustomerById(request.CustomerId, cancellationToken);

            if (customer is null) 
            {
                var validationErrorList = new List<ValidationError>()
                {
                    new ValidationError{ ErrorCode = "400", ErrorMessage = "Invalid customer" }
                };

                return Result.Invalid(validationErrorList);
            }

            Project project = new(request.Name, request.CustomerId);

            _projectRepository.Add(project);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
