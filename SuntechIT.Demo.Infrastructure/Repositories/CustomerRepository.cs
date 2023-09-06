using Ardalis.GuardClauses;
using SuntechIT.Demo.Domain.Entities.Customers;
using SuntechIT.Demo.Domain.Repositories;

namespace SuntechIT.Demo.Infrastructure.Repositories
{
    internal sealed class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = Guard.Against.Null(context);
        }

        public void Add(Customer customer)
        {
            _context.Set<Customer>().Add(customer);
        }
    }
}
