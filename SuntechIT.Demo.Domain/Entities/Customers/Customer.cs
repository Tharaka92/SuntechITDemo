using SuntechIT.Demo.Shared.Entity;
using System.ComponentModel.DataAnnotations;

namespace SuntechIT.Demo.Domain.Entities.Customers
{
    public class Customer : ITrackChanges
    {
        public long Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
