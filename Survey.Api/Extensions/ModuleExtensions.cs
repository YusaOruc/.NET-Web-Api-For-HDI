using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static Survey.Core.Extensions.ServiceCollectionExtensions;

namespace Survey.Api.Extensions
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddSurveyModule(this IServiceCollection services)
        {
            services.AddSurveyServices();
            return services;
        }
    }
}
