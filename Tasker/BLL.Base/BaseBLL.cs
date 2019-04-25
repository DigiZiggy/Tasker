using System;
using System.Threading.Tasks;
using Contracts.BLL.Base;
using Contracts.BLL.Base.Helpers;
using Contracts.BLL.Base.Services;
using Contracts.DAL.Base;

namespace BLL.Base
{
    public class BaseBLL : IBLL
    {
        public Guid InstanceId { get; } = Guid.NewGuid();

        protected readonly IUnitOfWork Uow;
        protected readonly IBaseServiceProvider ServiceProvider;

        public BaseBLL(IUnitOfWork uow, IBaseServiceProvider serviceProvider)
        {
            Uow = uow;
            ServiceProvider = serviceProvider;
        }

        public IBaseEntityService<TEntity> BaseEntityService<TEntity>() where TEntity : class, IBaseEntity<int>, new()
        {
            return ServiceProvider.GetEntityService<TEntity>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Uow.SaveChangesAsync();   
        }

    }
}