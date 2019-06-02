using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IUserTaskRepository : IBaseRepositoryAsync<UserTask>
    {
        Task<UserTask> FindAllIncludedAsync(params object[] id);
        Task<List<UserTask>> AllForTaskGiverAsync(int userId);
        Task<List<UserTask>> AllForTaskerAsync(int userId);
    }
}