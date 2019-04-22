using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
using Task = Domain.Task;

namespace Contracts.DAL.App.Repositories
{
    public interface ITaskRepository : IBaseRepositoryAsync<Task>
    {
        Task<IEnumerable<TaskDTO>> GetAllWithTaskAsync();

    }
}