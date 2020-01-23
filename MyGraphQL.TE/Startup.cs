
using System;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL.Types;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MyGraphQL.Api.Extensions;
using MyGraphQL.Api.Infrastructure;
using MyGraphQL.Api.IoC;
using MyGraphQL.Domain.EF;
using MyGraphQL.Infrastructure.GraphQL;
using MyGraphQL.Infrastructure.GraphQL.Configuration;
using MyGraphQL.Infrastructure.GraphQL.QM;
using MyGraphQL.Infrastructure.Service.Configuration;
using Newtonsoft.Json.Serialization;

namespace MyGraphQL.Api
{
    public class Startup
    {
        private bool IsDev = false;
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(env.ContentRootPath)
                                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                                     .AddEnvironmentVariables();

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
#if DEBUG
            IsDev = true;
#endif
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddGraphQLQueries();
            services.AddServices();
            services.AddHealthChecks()
                .AddCheck<WebApiHealthCheck>("example_health_check");
            services.RegisterIoC(Configuration);
            services.AddControllers().AddNewtonsoftJson(options =>
                   options.SerializerSettings.ContractResolver =
                      new CamelCasePropertyNamesContractResolver());

            services.AddAuthenticationSSOMiddleware();
            //services.AddIdentityServerAuthenticationMiddleware();
            services.AddAuthorizationPolicies();
        }

        private async Task InitializeDatabaseAsync(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                foreach (var contextType in new[]
                {
                    typeof(ArticlesDbContext)
                })
                {
                    await ((DbContext)serviceScope.ServiceProvider.GetRequiredService(contextType)).Database
                        .MigrateAsync();
                }
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Task.Run(async () => await InitializeDatabaseAsync(app)).Wait();
            if (IsDev)
                app.UseGraphiQl("/graphql");
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("default");

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
