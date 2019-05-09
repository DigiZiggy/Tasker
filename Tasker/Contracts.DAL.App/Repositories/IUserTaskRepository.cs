using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IUserTaskRepository : IBaseRepositoryAsync<UserTask, int>
    {
        Task<UserTask> FindAllIncludedAsync(params object[] id);      
    }
}