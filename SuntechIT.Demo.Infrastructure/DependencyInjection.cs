using Microsoft.Extensions.DependencyInjection;
using SuntechIT.Demo.Domain.Repositories;
using SuntechIT.Demo.Infrastructure.Repositories;

namespace SuntechIT.Demo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
