using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Customer?> GetCustomerById(long id, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
