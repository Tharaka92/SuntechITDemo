﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace SuntechIT.Demo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            var assembly = AssemblyReference.Assembly;

            services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);

            return services;
        }
    }
}
