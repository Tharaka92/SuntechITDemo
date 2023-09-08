using Ardalis.Result;
using MediatR;
using SuntechIT.Demo.Shared.Identity;

namespace SuntechIT.Demo.Application.Projects.Commands.Assign
{
    public sealed record AssignProjectCommand(long ProjectId, string UserId, CurrentUser CurrentUser) : IRequest<Result>;
}
