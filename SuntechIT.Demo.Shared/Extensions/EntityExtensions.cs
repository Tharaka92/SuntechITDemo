using System.Reflection;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using SuntechIT.Demo.Shared.Entity;

namespace SuntechIT.Demo.Shared.Extensions
{
    public static class EntityExtensions
    {
        public static void TrackUpdates(this ChangeTracker changeTracker)
        {
            (from x in changeTracker.Entries()
             where x.State == EntityState.Modified
             where x.Entity is ITrackChanges
             select x.Entity as ITrackChanges).ForEach(delegate (ITrackChanges x)
             {
                 x.UpdatedOn = DateTime.UtcNow;
             });
        }

        public static void SetupSqlServerTrackingFields<T>(this ModelBuilder modelBuilder) where T : DbContext
        {
            typeof(T).Assembly.DefinedTypes.Where((x) => x.ImplementedInterfaces.Contains(typeof(ITrackChanges))).ForEach(delegate (TypeInfo x)
            {
                modelBuilder.Entity(x.AsType()).Property("CreatedOn").HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();
                modelBuilder.Entity(x.AsType()).Property("UpdatedOn").HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();
            });
        }
    }
}
