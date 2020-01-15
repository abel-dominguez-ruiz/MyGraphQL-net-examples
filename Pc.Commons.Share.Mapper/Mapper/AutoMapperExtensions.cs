using System.Collections;
using System.Collections.Generic;
using AutoMapper;

namespace Pc.Commons.Share.Mapper
{
    public static class AutoMapperExtensions
    {
        public static void AddProfiles(this IMapperConfigurationExpression config, IEnumerable<Profile> profiles)
        {
            foreach (var profile in profiles)
            {
                config.AddProfile(profile);    
            }
        }
        
    }
}