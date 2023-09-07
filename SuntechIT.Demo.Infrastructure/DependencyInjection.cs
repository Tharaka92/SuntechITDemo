using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuntechIT.Demo.Application.Abstractions;
using SuntechIT.Demo.Domain.Repositories;
using SuntechIT.Demo.Infrastructure.Authentication;
using SuntechIT.Demo.Infrastructure.Helpers;
using SuntechIT.Demo.Infrastructure.Repositories;

namespace SuntechIT.Demo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration) 
        {
            // For Entity Framework
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DB")));

            // For Identity
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IDataSeeder, DataSeeder>()
                .AddScoped<IJwtProvider, JwtProvider>()
                .AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IProjectRepository, ProjectRepository>()
                .AddScoped<ITicketRepository, TicketRepository>();

            return services;
        }

        public static async Task SetupEntitiesAsync(this IServiceProvider serviceProvider)
        {
            await serviceProvider.MigrateAsync();

            using var scope = serviceProvider.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();

            await seeder.SeedAsync();
        }

        #region Private Static Methods
        private static async Task MigrateAsync(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            await context!.Database.MigrateAsync();
        }
        #endregion
    }
}
