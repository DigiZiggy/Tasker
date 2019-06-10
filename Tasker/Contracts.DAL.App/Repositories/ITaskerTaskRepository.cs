using System.Threading.Tasks;
using ee.itcollege.sigrid.narep.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;


namespace Contracts.DAL.App.Repositories
{
    public interface ITaskerTaskRepository : IBaseRepository<DALAppDTO.TaskerTask>
    {        
    }
    
    public interface ITaskerTaskRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
    }
}