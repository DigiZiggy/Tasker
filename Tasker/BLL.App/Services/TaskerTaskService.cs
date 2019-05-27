using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class TaskerTaskService : BaseEntityService<TaskerTask, IAppUnitOfWork>, ITaskerTaskService
    {
        public TaskerTaskService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<TaskerTask> FindAllIncludedAsync(params object[] id)
        {
            return await Uow.Tasks.FindAllIncludedAsync(id);

        }
    }
}