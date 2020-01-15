using Microsoft.Extensions.Configuration;
using System.IO;
namespace MyGraphQL.Domain.EF.Configuration
{
    public static class Configure
    {
        public static IConfigurationBuilder ConfigurationBuilder()
        {
            return new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        }
    }
}

