using Ardalis.Result;
using MediatR;

namespace SuntechIT.Demo.Application.Projects.Commands.Create
{
    public sealed record CreateProjectCommand(string Name, long CustomerId) : IRequest<Result>;
}
