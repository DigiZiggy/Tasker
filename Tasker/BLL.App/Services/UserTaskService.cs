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
    }
}