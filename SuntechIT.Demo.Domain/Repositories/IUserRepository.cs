using Microsoft.AspNetCore.Identity;

namespace SuntechIT.Demo.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityUser?> GetUserById(string id, CancellationToken cancellationToken);
        Task<List<IdentityUser>> GetUsers(long? customerId, long? projectId, CancellationToken cancellationToken);
    }
}
