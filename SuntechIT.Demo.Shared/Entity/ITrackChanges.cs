namespace SuntechIT.Demo.Shared.Entity
{
    public interface ITrackChanges
    {
        DateTime CreatedOn { get; set; }

        DateTime UpdatedOn { get; set; }
    }
}
