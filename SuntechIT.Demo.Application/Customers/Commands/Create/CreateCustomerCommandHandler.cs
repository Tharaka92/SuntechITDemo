using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using MediatR;
using SuntechIT.Demo.Application.Customers.Commands.Create.Validators;
using SuntechIT.Demo.Domain.Entities.Customers;
using SuntechIT.Demo.Domain.Repositories;
using System;

namespace SuntechIT.Demo.Application.Customers.Commands.Create
{
    internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository
            , IUnitOfWork unitOfWork)
        {
            _customerRepository = Guard.Against.Null(customerRepository);
            _unitOfWork = Guard.Against.Null(unitOfWork);
        }

        public async Task<Result> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerCommandValidator();

            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return Result.Invalid(result.AsErrors());
            }

            Customer customer = new(request.Name);

            _customerRepository.Add(customer);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
