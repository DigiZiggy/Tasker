using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.Base;

namespace BLL.Base.Services
{
    public class BaseEntityService<TEntity> : BaseService, IBaseEntityService<TEntity> where TEntity : class, IBaseEntity<int>, new()
    {
        protected readonly IUnitOfWork Uow;

        public BaseEntityService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        public TEntity Update(TEntity entity)
        {
            return Uow.BaseRepositoryAsync<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            Uow.BaseRepositoryAsync<TEntity>().Remove(entity);
        }

        public void Remove(params object[] id)
        {
            Uow.BaseRepositoryAsync<TEntity>().Remove(id);
        }

        public async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await Uow.BaseRepositoryAsync<TEntity>().AllAsync();
        }

        public async Task<TEntity> FindAsync(params object[] id)
        {
            return await Uow.BaseRepositoryAsync<TEntity>().FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Uow.BaseRepositoryAsync<TEntity>().AddAsync(entity);
        }
    }
}
