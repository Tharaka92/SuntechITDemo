using Ardalis.GuardClauses;
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
    }
}
