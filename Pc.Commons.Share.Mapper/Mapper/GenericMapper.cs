using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Pc.Commons.Share.Mapper.Interfaces;
using System.Linq.Expressions;

namespace Pc.Commons.Share.Mapper
{
    public class GenericMapper : IDataMapper
    {
        protected IConfigurationProvider MapperConfiguration { get; set; }
        protected IMapper Mapper { get; set; }

        public GenericMapper(Action<IMapperConfigurationExpression> automapperExpression)
        {
            MapperConfiguration = new MapperConfiguration(automapperExpression);
            Mapper = MapperConfiguration.CreateMapper();
        }

        public TOutput MapTo<TInput, TOutput>(TInput model)
        {
            return Mapper.Map<TOutput>(model);
        }

        public IEnumerable<TOutput> MapTo<TInput, TOutput>(IEnumerable<TInput> model)
        {
            return Mapper.Map<IEnumerable<TOutput>>(model);
        }

        public IQueryable<TOutput> ProjectTo<TInput, TOutput>(IQueryable<TInput> source)
        {
            return source.ProjectTo<TOutput>(MapperConfiguration, null, new string[] { });
        }

        public TOutput UpdateTo<TInput, TOutput>(TInput input, TOutput output)
        {
            return Mapper.Map(input, output);
        }

        public TOutput UpdateWith<TInput, TOutput>(TOutput dest, TInput updated)
        {
            return Mapper.Map(updated, dest);
        }
        
    }
}