using Ardalis.GuardClauses;
using MediatR;
using SuntechIT.Demo.Domain.Entities.Customers;
using SuntechIT.Demo.Domain.Repositories;

namespace SuntechIT.Demo.Application.Customers.Create
{
    internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository
            , IUnitOfWork unitOfWork)
        {
            _customerRepository = Guard.Against.Null(customerRepository);
            _unitOfWork = Guard.Against.Null(unitOfWork);
        }

        public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = new(request.Name, DateTime.UtcNow, DateTime.UtcNow);

            _customerRepository.Add(customer);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
