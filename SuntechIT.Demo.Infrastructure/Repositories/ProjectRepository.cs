using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using SuntechIT.Demo.Domain.Entities.Customers;
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

        public async Task<Project?> GetProjectById(long id, CancellationToken cancellationToken)
        {
            return await _context.Projects
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
