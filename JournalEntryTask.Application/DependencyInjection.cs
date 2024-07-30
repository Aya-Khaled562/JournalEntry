using FluentValidation;
using JournalEntryTask.Application.Common.Behaviors;
using JournalEntryTask.Application.Common.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace JournalEntryTask.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviors<,>));
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddMappings();
            return services;
        }
    }
}
