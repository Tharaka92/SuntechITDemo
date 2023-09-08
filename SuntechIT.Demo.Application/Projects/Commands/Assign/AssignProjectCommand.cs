using Ardalis.Result;
using MediatR;

namespace SuntechIT.Demo.Application.Projects.Commands.Assign
{
    public sealed record AssignProjectCommand(long ProjectId, string UserId) : IRequest<Result>;
}
