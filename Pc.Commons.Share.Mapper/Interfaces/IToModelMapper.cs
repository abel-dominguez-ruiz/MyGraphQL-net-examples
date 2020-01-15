using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pc.Commons.Share.Mapper.Interfaces
{
    public interface IToModelMapper<TEntity, TModel>: IDataMapper
    {
        TModel ToModel(TEntity input);
        IQueryable<TOutput> ProjectTo<TOutput>(IQueryable<TEntity> model);
    }
}