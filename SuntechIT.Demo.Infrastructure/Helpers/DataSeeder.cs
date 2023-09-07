using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using SuntechIT.Demo.Domain.Enums;

namespace SuntechIT.Demo.Infrastructure.Helpers
{
    public class DataSeeder : IDataSeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataSeeder(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = Guard.Against.Null(roleManager);
        }

        public async Task SeedAsync()
        {
            await CreateSuperAdminRoleAsync();
            await CreateAdminRoleAsync();
            await CreateNormalRoleAsync();
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

        private async Task<bool> IsRoleExistsAsync(string role) => await _roleManager.RoleExistsAsync(role);
        #endregion
    }
}
