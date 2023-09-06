using Ardalis.GuardClauses;
using MediatR;
using SuntechIT.Demo.Domain.Entities.Customers;

namespace SuntechIT.Demo.Application.Customers.Create
{
    internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = Guard.Against.Null(customerRepository);
        }

        public Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = new(request.Name, DateTime.UtcNow, DateTime.UtcNow);
            _customerRepository.Add(customer);
        }
    }
}
