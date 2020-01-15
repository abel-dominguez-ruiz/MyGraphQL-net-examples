using AutoMapper;
using System;
using System.Linq;
using Pc.Commons.Share.Mapper.Interfaces;
using System.Linq.Expressions;

namespace Pc.Commons.Share.Mapper
{
    public class ToModelMapper<TEntity, TModel> : GenericMapper, IToModelMapper<TEntity, TModel>
    {
        public ToModelMapper(Action<IMapperConfigurationExpression> automapperExpression)
            : base(automapperExpression)
        {
            if (MapperConfiguration.FindTypeMapFor<TEntity, TModel>() == null)
            {
                throw new Exception($"Missing type map for {typeof(TEntity).Name} -> {typeof(TModel).Name}");
            }
        }

        public TModel ToModel(TEntity entity)
        {
            return MapTo<TEntity, TModel>(entity);
        }

        public IQueryable<TOutput> ProjectTo<TOutput>(IQueryable<TEntity> model)
        {
            return ProjectTo<TEntity, TOutput>(model);
        }
    }
}