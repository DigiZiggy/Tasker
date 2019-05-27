using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface ITaskerTaskRepository : IBaseRepositoryAsync<TaskerTask>
    {
        Task<TaskerTask> FindAllIncludedAsync(params object[] id);      
        
    }
}