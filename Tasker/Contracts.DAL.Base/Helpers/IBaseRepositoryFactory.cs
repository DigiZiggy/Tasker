using System;

namespace Contracts.DAL.Base.Helpers
{
    public interface IBaseRepositoryFactory
    {
        Func<IDataContext, object> GetRepositoryFactory<TRepository>();

        Func<IDataContext, object> GetEntityRepositoryFactory<TEntity>()
            where TEntity : class, IBaseEntity<int>, new();

    }
}
