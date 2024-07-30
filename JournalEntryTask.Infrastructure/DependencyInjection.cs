using JournalEntryTask.Application.Common.Interfaces.Presistence;
using JournalEntryTask.Infrastructure.Presistence;
using JournalEntryTask.Infrastructure.Presistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JournalEntryTask.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            var connection = configuration.GetConnectionString("connection");

            services.AddDbContext<JournalEntryTaskContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("connection")));


            services.AddScoped<IAccountChartRepository, AccountChartRepository>();
            services.AddScoped<IJournalHeaderRepository, JournalHeaderRepository>();
            services.AddScoped<IJournalDetailsRepository, JournalDetailsRepository>();
            return services;
        }
    }
}
