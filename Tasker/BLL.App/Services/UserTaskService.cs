using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;


namespace BLL.App.Services
{
    public class UserTaskService : BaseEntityService<BLL.App.DTO.UserTask, DAL.App.DTO.UserTask, IAppUnitOfWork>, IUserTaskService
    {
        public UserTaskService(IAppUnitOfWork uow) : base(uow, new UserTaskMapper())
        {
            ServiceRepository = Uow.UserTasks;
        }


        public async Task<BLL.App.DTO.UserTask> FindAllIncludedAsync(params object[] id)
        {
            return UserTaskMapper.MapFromDAL(await Uow.UserTasks.FindAllIncludedAsync(id));
        }
        
        public async Task<BLL.App.DTO.UserTask> FindForUserAsync(int id, int userId)
        {
            return UserTaskMapper.MapFromDAL(await Uow.UserTasks.FindForUserAsync(id, userId));
        }
     
        public async Task<List<BLL.App.DTO.UserTask>> AllForTaskGiverAsync(int userId)
        {
            return (await Uow.UserTasks.AllForTaskGiverAsync(userId)).Select(e => UserTaskMapper.MapFromDAL(e)).ToList();
        }
        
        public async Task<List<BLL.App.DTO.UserTask>> AllForTaskerAsync(int userId)
        {
            return (await Uow.UserTasks.AllForTaskerAsync(userId)).Select(e => UserTaskMapper.MapFromDAL(e)).ToList();
        }
    }
}