using AutoMapper;

namespace Pc.Commons.Share.Mapper
{
    internal class GenericProfile<TEntity, TModel> : Profile
    {
        public GenericProfile()
        {
            CreateMap<TEntity, TModel>().ReverseMap();
        }
    }
}