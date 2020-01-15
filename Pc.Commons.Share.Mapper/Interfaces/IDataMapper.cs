using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pc.Commons.Share.Mapper.Interfaces
{
    public interface IDataMapper
    {
        TOutput MapTo<TInput, TOutput>(TInput model);
        TOutput UpdateWith<TInput, TOutput>(TOutput dest, TInput updated);
        IEnumerable<TOutput> MapTo<TInput, TOutput>(IEnumerable<TInput> model);
        IQueryable<TOutput> ProjectTo<TInput, TOutput>(IQueryable<TInput> model);

        TOutput UpdateTo<TInput, TOutput>(TInput input, TOutput output);
    }
}
