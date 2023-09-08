using Ardalis.Result;
using MediatR;
using SuntechIT.Demo.Shared.Identity;

namespace SuntechIT.Demo.Application.Projects.Queries.GetProjectById
{
    public sealed record GetProjectByIdQuery(long ProjectId, CurrentUser CurrentUser) : IRequest<Result<ProjectResponse>>;
}
