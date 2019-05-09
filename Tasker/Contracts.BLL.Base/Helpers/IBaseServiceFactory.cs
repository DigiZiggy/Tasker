using System;
using Contracts.DAL.Base;

namespace Contracts.BLL.Base.Helpers
{
    public interface IBaseServiceFactory
    {
        Func<IUnitOfWork, object> GetServiceFactory<TService>();

        Func<IUnitOfWork, object> GetEntityServiceFactory<TEntity>()
            where TEntity : class, IBaseEntity<int>, new();

    }
}
