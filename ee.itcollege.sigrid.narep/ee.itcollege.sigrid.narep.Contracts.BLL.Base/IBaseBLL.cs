using System.Threading.Tasks;
using Contracts.Base;

namespace ee.itcollege.sigrid.narep.Contracts.BLL.Base
{
    public interface IBaseBLL : ITrackableInstance
    {
        /*
        IBaseEntityService<TEntity> BaseEntityService<TEntity>() 
            where TEntity : class, IDomainEntity, new();
        */
        
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
