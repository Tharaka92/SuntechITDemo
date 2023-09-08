using Ardalis.GuardClauses;
using Ardalis.Result;
using MediatR;
using SuntechIT.Demo.Domain.Repositories;
using SuntechIT.Demo.Shared.Extensions;

namespace SuntechIT.Demo.Application.Projects.Queries.GetProjects
{
    internal sealed class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, Result<List<ProjectResponse>>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = Guard.Against.Null(projectRepository);
        }

        public async Task<Result<List<ProjectResponse>>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetProjects(request.CustomerId, request.UserId, request.CurrentUser, cancellationToken);

            if (projects.IsNullOrEmpty())
            {
                return Result.NotFound();
            }

            var projectResponses = projects.Select(x => new ProjectResponse(x.Id, x.Name)).ToList();

            return new Result<List<ProjectResponse>>(projectResponses);
        }
    }
}
