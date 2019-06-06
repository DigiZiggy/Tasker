using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;


namespace Contracts.DAL.App.Repositories
{
    public interface ITaskerTaskRepository : ITaskerTaskRepository<DALAppDTO.TaskerTask>
    {        
    }
    
    public interface ITaskerTaskRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        Task<TDALEntity> FindAllIncludedAsync(params object[] id);
        Task<TDALEntity> FindForUserAsync(int id, int userId);

    }
}