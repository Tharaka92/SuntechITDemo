namespace SuntechIT.Demo.Application.Tickets.Commands.Create
{
    public class CreateTicketRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public long ProjectId { get; set; }

        public string? UserId { get; set; }
    }
}
