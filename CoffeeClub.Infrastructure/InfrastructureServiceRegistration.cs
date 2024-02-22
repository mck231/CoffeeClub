﻿using CoffeeClub.Application.Contracts.Infrastructure;
using CoffeeClub.Application.Features.Coffee.Queries.GetCoffee;
using CoffeeClub.Application.Features.VotingSession.Queries.GetVotingSessionExcelFileQuery;
using CoffeeClub.Domain.Entities;
using CoffeeClub.Infrastructure.FileExport;
using CoffeeClub.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CoffeeClub.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICsvExporter<VoteSummaryDto>, CsvExporter>();
            return services;
        }
    }
}
