using SuntechIT.Demo.Shared.Entity;
using System.ComponentModel.DataAnnotations;

namespace SuntechIT.Demo.Domain.Entities.Customers
{
    public class Customer : ITrackChanges
    {
        public Customer(string name, DateTime createdOn, DateTime updatedOn)
        {
            Name = name;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
        }

        public long Id { get; private set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; private set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
