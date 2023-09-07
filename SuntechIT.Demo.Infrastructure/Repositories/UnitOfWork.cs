using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SuntechIT.Demo.Domain.Repositories;
using SuntechIT.Demo.Shared.Entity;

namespace SuntechIT.Demo.Infrastructure.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = Guard.Against.Null(dbContext);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditProperties();
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        #region Private Methods
        private void UpdateAuditProperties() 
        {
            IEnumerable<EntityEntry<IAuditable>> entries = _dbContext.ChangeTracker.Entries<IAuditable>();

            foreach (EntityEntry<IAuditable> entityEntry in entries) 
            {
                if (entityEntry.State == EntityState.Added) 
                {
                    entityEntry.Property(a => a.CreatedOn).CurrentValue = DateTime.UtcNow;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property(a => a.UpdatedOn).CurrentValue = DateTime.UtcNow;
                }
            }
        }
        #endregion
    }
}
