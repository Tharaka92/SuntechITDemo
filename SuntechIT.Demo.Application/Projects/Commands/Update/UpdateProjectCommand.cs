using Ardalis.Result;
using MediatR;
using SuntechIT.Demo.Shared.Identity;

namespace SuntechIT.Demo.Application.Projects.Commands.Update
{
    public sealed record UpdateProjectCommand(long Id, string Name, CurrentUser CurrentUser) : IRequest<Result>;
}
