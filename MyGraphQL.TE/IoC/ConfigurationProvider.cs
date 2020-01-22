using Microsoft.Extensions.Configuration;
using System;

namespace MyGraphQL.Api.IoC
{
    public static class ConfigurationProvider
    {
        public static IConfiguration Configuration;

        public static IConfiguration GetConfig()
        {
            if (Configuration == null)
            {
                Configuration = new ConfigurationBuilder()
                        .SetBasePath(Environment.CurrentDirectory)
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables()
                        .Build();
            }

            return Configuration;
        }
    }
}
