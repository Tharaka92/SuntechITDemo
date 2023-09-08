using SuntechIT.Demo.Domain.Entities.Projects;

namespace SuntechIT.Demo.Domain.Repositories
{
    public interface IProjectRepository
    {
        void Add(Project project);
        Task<Project?> GetProjectById(long id, bool noTracking, CancellationToken cancellationToken);
    }
}
