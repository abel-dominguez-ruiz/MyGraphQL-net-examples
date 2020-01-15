using Microsoft.Extensions.DependencyInjection;
using MyGraphQL.Infrastructure.GraphQL.QM;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGraphQL.Infrastructure.GraphQL.Configuration
{
    public static class GraphQLExtension
    {
        public static IServiceCollection AddGraphQLQueries(this IServiceCollection services)
        {
            services.AddTransient<ArticleSchema>();
            services.AddTransient<ArticleQuery>();
            services.AddTransient<ArticleMutation>();
            return services;
        }
    }
}
