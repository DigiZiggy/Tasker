using Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.Base.Helpers
{
    public interface IRepositoryProvider
    {
        //Return TRepository from cache, or call factory to create it
        TRepository GetRepository<TRepository>();

        IBaseRepositoryAsync<TEntity> GetRepositoryForEntity<TEntity>()
            where TEntity : class, IBaseEntity, new();
    }
}