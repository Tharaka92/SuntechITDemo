using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using SuntechIT.Demo.Domain.Entities.Projects;
using SuntechIT.Demo.Domain.Repositories;

namespace SuntechIT.Demo.Infrastructure.Repositories
{
    internal sealed class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = Guard.Against.Null(context);
        }

        public void Add(Project project)
        {
            _context.Set<Project>().Add(project);
        }

        public async Task<Project?> GetProjectById(long id, bool noTracking,CancellationToken cancellationToken)
        {
            var query = _context.Projects.AsQueryable();

            if (noTracking) 
            {
                query = query.AsNoTracking();
            }

            return await query
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
