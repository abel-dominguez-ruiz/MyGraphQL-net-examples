using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using MyGraphQL.Api.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGraphQL.Api.Extensions
{
    public static class AuthenticationExtensions
    {
        public static void AddAuthenticationSSOMiddleware(this IServiceCollection services)
        {
            ICollection<SecurityKey> signingKeys = GetSigninKeys();

            if (signingKeys == null || signingKeys.Count == 0)
            {
                return;
            }

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
          .AddJwtBearer(x =>
          {
              x.RequireHttpsMetadata = false;
              x.SaveToken = true;
              x.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateLifetime = true,
                  RequireSignedTokens = true,
                  ValidateAudience = false,
                  ValidIssuer = AppSettingsProvider.ValidIssuer,
                  ValidateIssuer = true,
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKeys = signingKeys
              };
          });
        }

        public static void AddIdentityServerAuthenticationMiddleware(this IServiceCollection services)
        {
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                            .AddIdentityServerAuthentication(options =>
                            {
                                options.Authority = AppSettingsProvider.ValidIssuer;
                                options.ApiName = "api";
                                options.RequireHttpsMetadata = false;
                                options.SaveToken = true;
                            });
        }


        public static void AddGoogleAuthenticationMiddleware(this IServiceCollection services)
        {
        }

        private static ICollection<SecurityKey> GetSigninKeys()
        {
            var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
               $"{AppSettingsProvider.ValidIssuer}/.well-known/openid-configuration",
               new OpenIdConnectConfigurationRetriever(),
               new HttpDocumentRetriever());
            var discoveryDocument = configurationManager.GetConfigurationAsync()
                        .GetAwaiter()
                        .GetResult();

            return discoveryDocument.SigningKeys;
        }
    }
}
