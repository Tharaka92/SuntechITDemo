using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuntechIT.Demo.Domain.Repositories;
using SuntechIT.Demo.Shared.Extensions;

namespace SuntechIT.Demo.Infrastructure.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = Guard.Against.Null(context);
        }

        public async Task<IdentityUser?> GetUserById(string id, CancellationToken cancellationToken)
        {
            return await _context.Users
                .AsNoTracking()
                .Select(u => new IdentityUser 
                { 
                    Id = u.Id, 
                    Email = u.Email, 
                    PhoneNumber = u.PhoneNumber 
                }).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<IdentityUser>> GetUsers(long? customerId, long? projectId, CancellationToken cancellationToken)
        {
            return await _context.Projects
                .Include(x => x.User)
                .AsNoTracking()
                .WhereIf(projectId.HasValue, x => x.Id == projectId.Value)
                .WhereIf(customerId.HasValue, x => x.CustomerId == customerId.Value)
                .Select(x => new IdentityUser
                {
                    Id = x.UserId,
                    Email = x.User.Email,
                    PhoneNumber = x.User.PhoneNumber
                }).ToListAsync(cancellationToken);
        }
    }
}
