namespace SuntechIT.Demo.Shared.Entity
{
    public interface IAuditable
    {
        DateTime CreatedOn { get; set; }

        DateTime UpdatedOn { get; set; }
    }
}
