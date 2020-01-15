using System;
using System.Collections.Generic;
using AutoMapper;

namespace Pc.Commons.Share.Mapper.Interfaces
{
    public interface IMapperBuilder
    {
        IMapperBuilder AddProfile(IEnumerable<Profile> profiles);
        [Obsolete]
        IMapperBuilder AddProfile(Profile profile);
        IMapperBuilder AddProfile<T>() where T : Profile, new();

        IMapperBuilder AddMapping<TInput, TOutput>();
        IToModelMapper<TEntity, TModel> BuildToModelMapper<TEntity, TModel>(string caller);
        ITwoWayMapper<TEntity, TModel> BuildTwoWayMapper<TEntity, TModel>(string caller);
    }
}