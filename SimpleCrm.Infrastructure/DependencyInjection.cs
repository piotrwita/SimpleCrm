using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleCrm.Domain.Interfaces;
using SimpleCrm.Infrastructure.Repositories;
using System.Reflection;

namespace SimpleCrm.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        { 
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}
