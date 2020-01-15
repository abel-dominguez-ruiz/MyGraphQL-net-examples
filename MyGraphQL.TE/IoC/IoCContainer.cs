using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyGraphQL.Domain.EF;

namespace MyGraphQL.Api.IoC
{
    public static class IoCContainer
    {
        public static void RegisterIoC(this IServiceCollection services, IConfiguration Configuration)
        {
            string sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ArticlesDbContext>(options =>
            {
                options.UseSqlServer(sqlConnectionString);
                options.UseLoggerFactory(services.BuildServiceProvider().GetService<ILoggerFactory>());
            }
        );
        }
    }
}
