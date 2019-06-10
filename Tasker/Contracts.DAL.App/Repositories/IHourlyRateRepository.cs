using ee.itcollege.sigrid.narep.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;


namespace Contracts.DAL.App.Repositories
{
    public interface IHourlyRateRepository : IBaseRepository<DALAppDTO.HourlyRate>
    {
        
    }
    
    public interface IHourlyRateRepository<TDALEntity> : IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {      
        
    }
}