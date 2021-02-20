using CustomerVehicle.Repository.Interfaces.Application;
using CustomerVehicle.Repository.Repositories.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerVehicle.Repository
{
    public static class DependencyInjectionRepository
    {
        public static IServiceCollection IoCRegistrationRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();

            return services;
        }
    }
}