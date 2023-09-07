using Microsoft.AspNetCore.Identity;

namespace SuntechIT.Demo.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityUser?> GetUserById(string id, CancellationToken cancellationToken);
    }
}
