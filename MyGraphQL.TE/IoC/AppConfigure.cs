using Microsoft.Extensions.Configuration;


namespace MyGraphQL.Api.IoC
{
    public class AppSettingsProvider
    {
        private static IConfiguration Config => ConfigurationProvider.GetConfig();

        public static string ValidIssuer => Config.GetValue<string>("AuthorizationServer:ValidIssuer");
    }
}
