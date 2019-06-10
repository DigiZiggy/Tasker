using ee.itcollege.sigrid.narep.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories.Enums
{   
    public interface ITaskTypeRepository<TDALEntity> : IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {      
        
    }
}