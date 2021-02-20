using CustomerVehicle.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerVehicle.Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection IoCRegistrationInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTime, ServerDateTime>();
            
            return services;
        }
    }
}