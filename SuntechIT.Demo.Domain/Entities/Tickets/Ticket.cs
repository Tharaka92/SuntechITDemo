using Microsoft.AspNetCore.Identity;
using SuntechIT.Demo.Domain.Entities.Projects;
using SuntechIT.Demo.Domain.Enums;
using SuntechIT.Demo.Shared.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuntechIT.Demo.Domain.Entities.Tickets
{
    public class Ticket : IAuditable
    {
        public Ticket(string name, string description, long projectId)
        {
            Name = name;
            Description = description;
            ProjectId = projectId;
        }

        public long Id { get; private set; }

        public long ProjectId { get; private set; }

        public string? UserId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; private set; }

        [MaxLength(500)]
        public string Description { get; private set; }

        public TicketStatus Status { get; private set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser? User { get; private set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; private set; }
    }
}
