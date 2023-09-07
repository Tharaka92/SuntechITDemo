using Ardalis.GuardClauses;
using SuntechIT.Demo.Domain.Entities.Tickets;
using SuntechIT.Demo.Domain.Repositories;

namespace SuntechIT.Demo.Infrastructure.Repositories
{
    internal sealed class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = Guard.Against.Null(context);
        }

        public void Add(Ticket ticket)
        {
            _context.Set<Ticket>().Add(ticket);
        }
    }
}
