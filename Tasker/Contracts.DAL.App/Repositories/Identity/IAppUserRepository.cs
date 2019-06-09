using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;


namespace Contracts.DAL.App.Repositories.Identity
{
    public interface IAppUserRepository : IBaseRepository<DALAppDTO.Identity.AppUser>
    {
        
    }
    
    public interface IAppUserRepository<TDALEntity> : IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {      
        
    }
}