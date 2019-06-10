using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.sigrid.narep.BLL.Base.Services;


namespace BLL.App.Services
{
    public class UserTaskService : BaseEntityService<BLL.App.DTO.UserTask, DAL.App.DTO.UserTask, IAppUnitOfWork>, IUserTaskService
    {
        public UserTaskService(IAppUnitOfWork uow) : base(uow, new UserTaskMapper())
        {
            ServiceRepository = Uow.UserTasks;
        }


        public override async Task<BLL.App.DTO.UserTask> FindAsync(params object[] id)
        {
            return UserTaskMapper.MapFromDAL(await Uow.UserTasks.FindAsync(id));
        }
    }
}