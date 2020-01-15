namespace Pc.Commons.Share.Mapper.Interfaces
{
    public interface ITwoWayMapper<TEntity,TModel> : IToModelMapper<TEntity, TModel>
    {
        TEntity ToEntity(TModel input);
    }
}