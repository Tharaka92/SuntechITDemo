using Ardalis.Result;
using MediatR;

namespace SuntechIT.Demo.Application.Tickets.Commands.Create
{
    public sealed record CreateTicketCommand(string Name,
        string Description,
        long ProjectId,
        string? UserId) : IRequest<Result>;
}
