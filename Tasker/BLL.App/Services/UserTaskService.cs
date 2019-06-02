using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class UserTaskService : BaseEntityService<UserTask, IAppUnitOfWork>, IUserTaskService
    {
        public UserTaskService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<UserTask> FindAllIncludedAsync(params object[] id)
        {
            return await Uow.UserTasks.FindAllIncludedAsync(id);
        }
        
        public async Task<List<UserTask>> AllForTaskGiverAsync(int userId)
        {
            return await Uow.UserTasks.AllForTaskGiverAsync(userId);
        }
        
        public async Task<List<UserTask>> AllForTaskerAsync(int userId)
        {
            return await Uow.UserTasks.AllForTaskerAsync(userId);
        }
    }
}