using ee.itcollege.sigrid.narep.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;


namespace Contracts.DAL.App.Repositories
{
    public interface ISkillRepository : IBaseRepository<DALAppDTO.Skill>
    {
        
    }
    
    public interface ISkillRepository<TDALEntity> : IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {      
        
    }
}