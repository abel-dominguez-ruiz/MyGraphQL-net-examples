using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MyGraphQL.Api.AuthorizationRequirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGraphQL.Api.Extensions
{
    public static class AuthorizationExtensions
    {
        public static void AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                //options.AddPolicy("ApiPolicies", policy => policy.RequireClaim("scope", "api.full_access"));
                //options.AddPolicy("ApiPolicies", builder =>
                //{
                //    builder.RequireScope("api");
                //});
                options.AddPolicy("IsAdmin", policy => policy.AddRequirements(new IsAdminRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, IsAdminHandler>();
        }
    }
}
