using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Auth.Core.Extensions.ServiceCollectionExtensions;
using static Auth.Core.Extensions.SwaggerExtensions;
using static Auth.Core.Extensions.JwtAuthenticationExtensions;
using Microsoft.Extensions.Configuration;

namespace Auth.Api.Extensions
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddAuthModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddJwtAuthenticationExtension(configuration);
            services.AddAuthServices();
            services.AddSwaggerExtension();
            return services;
        }
    }
}
