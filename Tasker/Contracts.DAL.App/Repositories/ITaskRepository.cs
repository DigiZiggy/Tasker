using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Task = Domain.Task;

namespace Contracts.DAL.App.Repositories
{
    public interface ITaskRepository : IBaseRepositoryAsync<Task>
    {
    }
}