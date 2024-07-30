using JournalEntryTask.Api.Common.Errors;
using JournalEntryTask.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace JournalEntryTask.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //Override defualt of ProblemDetailsFactory which is responsible for Problem return to my Implementation
            services.AddSingleton<ProblemDetailsFactory , JournalEntryProblemDetailsFactory>();
            services.AddMappings();
            return services;
        }
    }
}
