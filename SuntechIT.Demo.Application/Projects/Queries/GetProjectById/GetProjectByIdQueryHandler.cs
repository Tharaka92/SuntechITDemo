using Ardalis.GuardClauses;
using Ardalis.Result;
using MediatR;
using SuntechIT.Demo.Domain.Repositories;

namespace SuntechIT.Demo.Application.Projects.Queries.GetProjectById
{
    internal sealed class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Result<ProjectResponse>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = Guard.Against.Null(projectRepository);
        }

        public async Task<Result<ProjectResponse>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.ProjectId <= 0)
            {
                var validationErrorList = new List<ValidationError>();
                return Result<ProjectResponse>.Invalid(validationErrorList);
            }

            var project = await _projectRepository.GetProjectById(request.ProjectId, true, request.CurrentUser, cancellationToken);

            if (project is null)
            {
                return Result<ProjectResponse>.NotFound();
            }

            var response = new ProjectResponse(project.Id, project.Name);

            return new Result<ProjectResponse>(response);
        }
    }
}
