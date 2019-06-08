using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;


namespace BLL.App.Services
{
    public class TaskerTaskService : BaseEntityService<BLL.App.DTO.TaskerTask, DAL.App.DTO.TaskerTask, IAppUnitOfWork>, ITaskerTaskService
    {
        public TaskerTaskService(IAppUnitOfWork uow) : base(uow, new TaskerTaskMapper())
        {
            ServiceRepository = Uow.Tasks;
        }

        public async Task<BLL.App.DTO.TaskerTask> FindAllIncludedAsync(params object[] id)
        {
            return TaskerTaskMapper.MapFromDAL(await Uow.Tasks.FindAllIncludedAsync(id));
        }
        
        public async Task<BLL.App.DTO.TaskerTask> FindForUserAsync(int id, int userId)
        {
            return TaskerTaskMapper.MapFromDAL(await Uow.Tasks.FindForUserAsync(id, userId));
        }
    }
}