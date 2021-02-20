using CsvHelper;
using CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles.VehicleProvider;
using CustomerVehicle.Service.Behaviours;
using CustomerVehicle.Service.Interfaces;
using CustomerVehicle.Service.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Reflection;

namespace CustomerVehicle.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection IoCRegistrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Performance<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Validation<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(GeneralException<,>));
            
            services.AddTransient<Stopwatch>();
            services.AddTransient<VehicleListProviderFactory>();

            //Services
            services.AddTransient<IDataValidationService, DataValidationService>();

            return services;
        }
    }
}