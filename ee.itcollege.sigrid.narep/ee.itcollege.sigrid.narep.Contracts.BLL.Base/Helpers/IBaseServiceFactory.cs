using System;
using ee.itcollege.sigrid.narep.Contracts.DAL.Base;

namespace ee.itcollege.sigrid.narep.Contracts.BLL.Base.Helpers
{
    public interface IBaseServiceFactory<TUnitOfWork>
        where TUnitOfWork : IBaseUnitOfWork
    {
        void AddToCreationMethods<TService>(Func<TUnitOfWork, TService> creationMethod)
            where TService : class;

        Func<TUnitOfWork, object> GetServiceFactory<TService>();

        /*
        // Too many generics needed, not doing it!
        Func<TUnitOfWork, object> GetEntityServiceFactory<TEntity>()
            where TEntity : class, IDomainEntity, new();
        */
    }
}
