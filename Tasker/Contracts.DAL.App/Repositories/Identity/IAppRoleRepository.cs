using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;


namespace Contracts.DAL.App.Repositories.Identity
{
    public interface IAppRoleRepository : IAppRoleRepository<DALAppDTO.Identity.AppRole>
    {
        
    }
    
    public interface IAppRoleRepository<TDALEntity> : IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {      
        
    }
}