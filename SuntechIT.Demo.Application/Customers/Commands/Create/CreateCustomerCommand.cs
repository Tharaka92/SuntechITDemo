using Ardalis.Result;
using MediatR;

namespace SuntechIT.Demo.Application.Customers.Commands.Create
{
    public sealed record CreateCustomerCommand(string Name) : IRequest<Result>;
}
