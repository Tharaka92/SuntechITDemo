using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using MediatR;
using SuntechIT.Demo.Application.Projects.Commands.Update.Validators;
using SuntechIT.Demo.Domain.Repositories;

namespace SuntechIT.Demo.Application.Projects.Commands.Update
{
    internal sealed class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Result>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository,
            IUnitOfWork unitOfWork)
        {
            _projectRepository = Guard.Against.Null(projectRepository);
            _unitOfWork = Guard.Against.Null(unitOfWork);
        }

        public async Task<Result> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProjectCommandValidator();

            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return Result.Invalid(result.AsErrors());
            }

            var project = await _projectRepository.GetProjectById(request.Id, false, request.CurrentUser, cancellationToken);

            if (project is null) 
            {
                return Result.NotFound();
            }

            project.Update(request.Name);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
