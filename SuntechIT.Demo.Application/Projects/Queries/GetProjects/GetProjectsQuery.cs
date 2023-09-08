using Ardalis.Result;
using MediatR;
using SuntechIT.Demo.Shared.Identity;

namespace SuntechIT.Demo.Application.Projects.Queries.GetProjects
{
    public sealed record GetProjectsQuery(long? CustomerId,
        string UserId,
        CurrentUser CurrentUser) : IRequest<Result<List<ProjectResponse>>>;
}
