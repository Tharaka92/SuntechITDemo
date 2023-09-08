using Ardalis.Result;
using MediatR;
using SuntechIT.Demo.Shared.Identity;

namespace SuntechIT.Demo.Application.Tickets.Commands.Create
{
    public sealed record CreateTicketCommand(string Name,
        string Description,
        long ProjectId,
        string? UserId,
        CurrentUser CurrentUser) : IRequest<Result>;
}
