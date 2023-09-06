using MediatR;

namespace SuntechIT.Demo.Application.Customers.Create
{
    public sealed record CreateCustomerCommand(string Name) : IRequest;
}
