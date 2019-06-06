using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;


namespace Contracts.DAL.App.Repositories
{
    public interface IUserTaskRepository : IUserTaskRepository<DALAppDTO.UserTask>
    {
        
    }
    
    public interface IUserTaskRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllForTaskGiverAsync(int userId);
        Task<List<TDALEntity>> AllForTaskerAsync(int userId);
        Task<TDALEntity> FindAllIncludedAsync(params object[] id);
        Task<TDALEntity> FindForUserAsync(int id, int userId);
    }

}