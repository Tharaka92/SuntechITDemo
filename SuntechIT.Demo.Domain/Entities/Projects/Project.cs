using Microsoft.AspNetCore.Identity;
using SuntechIT.Demo.Domain.Entities.Customers;
using SuntechIT.Demo.Domain.Entities.Tickets;
using SuntechIT.Demo.Shared.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuntechIT.Demo.Domain.Entities.Projects
{
    public class Project : IAuditable
    {
        public Project(string name, long customerId)
        {
            Name = name;
            CustomerId = customerId;
        }

        public long Id { get; private set; }

        public long CustomerId { get; private set; }

        public string? UserId { get; private set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; private set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; private set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser? User { get; private set; }

        public List<Ticket> Tickets { get; private set; }

        public void Assign(string userId) 
        {
            UserId = userId;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
