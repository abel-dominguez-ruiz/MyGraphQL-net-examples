using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Pc.Commons.Share.Mapper.Interfaces;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace Pc.Commons.Share.Mapper
{
    public class MapperBuilder: IMapperBuilder
    {
        private readonly object _lockObject = new object();
        protected List<Profile> _profileList = new List<Profile>();
        protected static ConcurrentDictionary<string, Profile> _profileInstances = new ConcurrentDictionary<string, Profile>();
        protected static ConcurrentDictionary<(Type, Type, string), IDataMapper> _mapperInstances = new ConcurrentDictionary<(Type, Type, string), IDataMapper>();

        public IMapperBuilder AddProfile(IEnumerable<Profile> profiles)
        {
            lock (_lockObject)
            {
                _profileList.AddRange(profiles);
            }
            return this;
        }

        public IMapperBuilder AddProfile<T>() where T : Profile, new()
        {
            lock (_lockObject)
            {
                var itemProfile = _profileInstances.GetOrAdd(typeof(T).Name, (key) => new T());
                _profileList.Add(itemProfile);
            }
            return this;
        }

        public IMapperBuilder AddProfile(Profile profile)
        {
            lock (_lockObject)
            {
                _profileList.Add(profile);
            }
            return this;
        }

        public IMapperBuilder AddMapping<TInput, TOutput>()
        {
            lock (_lockObject)
            {
                return AddProfile(new GenericProfile<TInput, TOutput>());
            }
        }


        public virtual IToModelMapper<TEntity, TModel> BuildToModelMapper<TEntity, TModel>(string caller)
        {
            return _mapperInstances.GetOrAdd(
                (typeof(TEntity), typeof(TModel), caller),
                (key) => new ToModelMapper<TEntity, TModel>(config => config.AddProfiles(_profileList))
            ) as IToModelMapper<TEntity, TModel>;
            
        }

        public virtual ITwoWayMapper<TEntity, TModel> BuildTwoWayMapper<TEntity, TModel>(string caller)
        {
            return _mapperInstances.GetOrAdd(
                (typeof(TEntity), typeof(TModel), caller),
                (key) => new TwoWayMapper<TEntity, TModel>(config => config.AddProfiles(_profileList))
            ) as ITwoWayMapper<TEntity, TModel>;
            
        }

    }
}
