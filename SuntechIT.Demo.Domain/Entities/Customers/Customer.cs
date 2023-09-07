using SuntechIT.Demo.Shared.Entity;
using System.ComponentModel.DataAnnotations;

namespace SuntechIT.Demo.Domain.Entities.Customers
{
    public class Customer : IAuditable
    {
        public Customer(string name)
        {
            Name = name;
        }

        public long Id { get; private set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; private set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
