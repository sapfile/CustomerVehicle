using CustomerVehicle.Persistence.Context;
using CustomerVehicle.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CustomerVehicle.Persistence
{
    public static class DependencyInjectionPersistence
    {
        public static IServiceCollection IoCRegistrationPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerVehicleDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CustomerVehicle")));
            
            services.AddScoped<Func<ICustomerVehicleDbContext>>(provider => () => provider.GetService<CustomerVehicleDbContext>());

            return services;
        }
    }
}