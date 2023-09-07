using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuntechIT.Demo.Domain.Repositories;

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
    }
}
