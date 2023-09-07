using SuntechIT.Demo.Domain.Entities.Tickets;

namespace SuntechIT.Demo.Domain.Repositories
{
    public interface ITicketRepository
    {
        void Add(Ticket ticket);
    }
}
