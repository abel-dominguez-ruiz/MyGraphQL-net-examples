using IdentityModel;
using MyGraphQL.Api.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;

namespace MyGraphQL.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {

        public static UserToken ToUserToken(this ClaimsPrincipal principal)
        {
            try
            {
                var claims = principal.Claims.ToClaimsDictionary();
                var result = new UserToken
                {
                    IdentityId = claims[JwtClaimTypes.Subject] as string,
                    UserName = claims[JwtClaimTypes.PreferredUserName] as string,
                    Email = claims[JwtClaimTypes.Email] as string,
                    FirstName = claims[JwtClaimTypes.GivenName] as string,
                    LastName = claims[JwtClaimTypes.FamilyName] as string,
                    UpdatedAt = (DateTime)claims[JwtClaimTypes.UpdatedAt],
                };
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Dictionary<string, object> ToClaimsDictionary(this IEnumerable<Claim> claims)
        {
            return claims
                .Distinct(new ClaimComparer())
                .GroupBy(c => c.Type)
                .ToDictionary(g => g.Key, g => g.Count() > 1 ? g.Select(GetValue).ToList() : GetValue(g.FirstOrDefault()));

        }

        private static object GetValue(Claim claim)
        {
            switch (claim.ValueType)
            {
                case ClaimValueTypes.String:
                    return claim.Value;
                case ClaimValueTypes.Integer:
                case ClaimValueTypes.Integer32:
                    if (Int32.TryParse(claim.Value, out var int32))
                    {
                        return int32;
                    }
                    break;
                case ClaimValueTypes.Integer64:
                    if (Int64.TryParse(claim.Value, out var int64))
                    {
                        return int64;
                    }
                    break;
                case ClaimValueTypes.Boolean:
                    if (Boolean.TryParse(claim.Value, out var boolean))
                    {
                        return boolean;
                    }
                    break;
                case ClaimValueTypes.DateTime:
                case "System.DateTime":
                    if (DateTime.TryParse(claim.Value.Trim('"'), CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var date))
                    {
                        return date;
                    }
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }
            return claim.Value;
        }
    }
}
