using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Survey.Core.Interfaces;
using Survey.Core.MapperProfiles;
using Survey.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSurveyServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SurveyProfile));
            services.AddScoped<ISurveyService, SurveyService>();
        }
    }
}
