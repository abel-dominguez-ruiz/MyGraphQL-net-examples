using System;
using System.Collections.Generic;
using AutoMapper;
using Pc.Commons.Share.Mapper.Interfaces;

namespace Pc.Commons.Share.Mapper
{
    public class TwoWayMapper<TEntity, TModel> : ToModelMapper<TEntity, TModel>, ITwoWayMapper<TEntity, TModel>
    {
        public TwoWayMapper(Action<IMapperConfigurationExpression> automapperExpression)
            : base(automapperExpression)
        {
            if (MapperConfiguration.FindTypeMapFor<TModel, TEntity>() == null)
            {
                throw new Exception($"Missing type map for {typeof(TModel).Name} -> {typeof(TEntity).Name}");
            }
        }

        public List<TEntity> ToEntity(List<TModel> model)
        {
            return Mapper.Map<List<TEntity>>(model);
        }

        public TEntity ToEntity(TModel model)
        {
            return MapTo<TModel, TEntity>(model);
        }
    }
}