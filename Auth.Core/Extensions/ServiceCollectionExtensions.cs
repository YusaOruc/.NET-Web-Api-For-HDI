using Auth.Core.Interfaces;
using Auth.Core.MapperProfile;
using Auth.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAuthServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISessionService, SessionService>();
        }
    }
}
