using BLL.Base.Services;
using Contracts.BLL.App.Services.Identity;
using Contracts.DAL.App;
using Domain.Identity;

namespace BLL.App.Services
{
    public class AppRoleService : BaseEntityService<AppRole, IAppUnitOfWork>, IAppRoleService
    {
        public AppRoleService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}