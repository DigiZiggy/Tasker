﻿using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.Base
{
    public interface IUnitOfWork
    {
        IBaseRepositoryAsync<TEntity> BaseRepositoryAsync<TEntity>() 
            where TEntity : class, IBaseEntity<int>, new();
        Task<int> SaveChangesAsync();        
        int SaveChanges();
       
    }
}
