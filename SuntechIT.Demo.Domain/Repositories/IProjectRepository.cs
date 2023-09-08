using SuntechIT.Demo.Domain.Entities.Projects;
using SuntechIT.Demo.Shared.Identity;

namespace SuntechIT.Demo.Domain.Repositories
{
    public interface IProjectRepository
    {
        void Add(Project project);
        Task<List<Project>> GetProjects(long? customerId, string? userId, CurrentUser currentUser, CancellationToken cancellationToken);
        Task<Project?> GetProjectById(long id, bool noTracking, CancellationToken cancellationToken);
    }
}
