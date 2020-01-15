using Microsoft.Extensions.DependencyInjection;
using MyGraphQL.Infrastructure.Service.Interfaces;
using MyGraphQL.Infrastructure.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGraphQL.Infrastructure.Service.Configuration
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IReadArticleService, ArticleService>();
            services.AddTransient<IWriteArticleService, ArticleService>();
            return services;
        }

    }
}
