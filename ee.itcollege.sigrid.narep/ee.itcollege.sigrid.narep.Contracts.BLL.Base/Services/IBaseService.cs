using Contracts.Base;
using ee.itcollege.sigrid.narep.Contracts.DAL.Base.Repositories;

namespace ee.itcollege.sigrid.narep.Contracts.BLL.Base.Services
{
    public interface IBaseService : ITrackableInstance
    {
    }
    
    public interface IBaseEntityService<TBLLEntity> : IBaseService, IBaseRepository<TBLLEntity> 
        where TBLLEntity : class, new()
    {
        
    }
}
