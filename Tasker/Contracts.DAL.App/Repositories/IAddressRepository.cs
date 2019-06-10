using ee.itcollege.sigrid.narep.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IAddressRepository : IBaseRepository<DALAppDTO.Address>
    {
        
    }
    
    public interface IAddressRepository<TDALEntity> : IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {      
        
    }
}