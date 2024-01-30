using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CoffeeClub.Application.Contracts.Infrastructure;
using CoffeeClub.Application.Services;
using MediatR;


namespace CoffeeClub.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddTransient<IVotingService, VotingService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            }); return services;

        }
    }
}
