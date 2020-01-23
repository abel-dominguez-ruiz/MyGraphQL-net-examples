using Microsoft.Extensions.Configuration;


namespace MyGraphQL.Api.IoC
{
    public class AppSettingsProvider
    {
        private static IConfiguration Config => ConfigurationProvider.GetConfig();

        public static string ValidIssuer => Config.GetValue<string>("AuthorizationServer:ValidIssuer");
        //public static string GoogleClientId => Config.GetValue<string>("GoogleAuthentication:GoogleClientId");
        //public static string GoogleClientSecret => Config.GetValue<string>("GoogleAuthentication:GoogleClientSecret");

        //public static string FacebookClientId => Config.GetValue<string>("FacebookAuthentication:FacebookClientId");
        //public static string FacebookClientSecret => Config.GetValue<string>("FacebookAuthentication:FacebookClientSecret");
    }
}
