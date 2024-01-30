using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoffeeClub.Application.Contracts.Persistence;
using CoffeeClub.Persistence.Repositories;

namespace CoffeeClub.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<CoffeeClubDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CoffeeClubConnectionString"))
            .EnableSensitiveDataLogging());

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICoffeeRepository, CoffeeRepository>();
            services.AddScoped<ICoffeeGroupRepository, CoffeeGroupRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IVotingSessionRepository, VotingSessionRepository>();
            services.AddScoped<ICoffeeSelectionRepository, CoffeeSelectionRepository>();

            return services;
        }
    }
}
