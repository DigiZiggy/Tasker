﻿using System;
using System.Threading.Tasks;
using Contracts.Base;
using Contracts.BLL.Base.Services;
using Contracts.DAL.Base;

namespace Contracts.BLL.Base
{
    public interface IBLL : ITrackableInstance
    {
        IBaseEntityService<TEntity> BaseEntityService<TEntity>()
            where TEntity : class, IBaseEntity<int>, new();
        
        Task<int> SaveChangesAsync();
    }
}