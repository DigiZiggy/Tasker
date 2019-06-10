using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.sigrid.narep.BLL.Base.Services;


namespace BLL.App.Services
{
    public class TaskerTaskService : BaseEntityService<BLL.App.DTO.TaskerTask, DAL.App.DTO.TaskerTask, IAppUnitOfWork>, ITaskerTaskService
    {
        public TaskerTaskService(IAppUnitOfWork uow) : base(uow, new TaskerTaskMapper())
        {
            ServiceRepository = Uow.Tasks;
        }

        public override async Task<BLL.App.DTO.TaskerTask> FindAsync(params object[] id)
        {
            return TaskerTaskMapper.MapFromDAL(await Uow.Tasks.FindAsync(id));
        }

    }
}