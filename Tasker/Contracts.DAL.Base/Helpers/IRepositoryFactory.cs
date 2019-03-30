using System;

namespace Contracts.DAL.Base.Helpers
{
    public interface IRepositoryFactory
    {
        //Get method for repo creation
        Func<IDataContext, object> GetRepositoryFactory<TRepo>();
        
        //Get method for repo creation based on entity
        Func<IDataContext, object> GetRepositoryFactoryForEntity<TEntity>()
            where TEntity: class, IBaseEntity, new();

    }
}