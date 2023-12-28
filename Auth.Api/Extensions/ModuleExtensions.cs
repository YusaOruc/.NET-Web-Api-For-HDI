using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Auth.Core.Extensions.ServiceCollectionExtensions;

namespace Auth.Api.Extensions
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddAuthModule(this IServiceCollection services)
        {
            services.AddAuthServices();
            return services;
        }
    }
}
