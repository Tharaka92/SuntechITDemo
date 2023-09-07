using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuntechIT.Demo.Domain.Entities.Customers;
using SuntechIT.Demo.Domain.Enums;
using SuntechIT.Demo.Domain.Repositories;

namespace SuntechIT.Demo.Infrastructure.Helpers
{
    public class DataSeeder : IDataSeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public DataSeeder(RoleManager<IdentityRole> roleManager,
             ApplicationDbContext dbContext,
             IUnitOfWork unitOfWork)
        {
            _roleManager = Guard.Against.Null(roleManager);
            _dbContext = Guard.Against.Null(dbContext);
            _unitOfWork = Guard.Against.Null(unitOfWork);
        }

        public async Task SeedAsync()
        {
            await CreateSuperAdminRoleAsync();
            await CreateAdminRoleAsync();
            await CreateNormalRoleAsync();
            await CreateCustomersAsync();
        }

        #region Private Methods
        private async Task CreateSuperAdminRoleAsync()
        {
            if (await IsRoleExistsAsync(Role.SuperAdmin.ToString()))
                return;

            await _roleManager.CreateAsync(new IdentityRole(Role.SuperAdmin.ToString()));
        }

        private async Task CreateAdminRoleAsync()
        {
            if (await IsRoleExistsAsync(Role.Admin.ToString()))
                return;

            await _roleManager.CreateAsync(new IdentityRole(Role.Admin.ToString()));
        }

        private async Task CreateNormalRoleAsync()
        {
            if (await IsRoleExistsAsync(Role.Normal.ToString()))
                return;

            await _roleManager.CreateAsync(new IdentityRole(Role.Normal.ToString()));
        }

        private async Task CreateCustomersAsync()
        {
            if (await _dbContext.Customers.AnyAsync())
                return;

            _dbContext.Customers.Add(new Customer("Tharaka"));
            _dbContext.Customers.Add(new Customer("Lahiru"));

            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<bool> IsRoleExistsAsync(string role) => await _roleManager.RoleExistsAsync(role);
        #endregion
    }
}
