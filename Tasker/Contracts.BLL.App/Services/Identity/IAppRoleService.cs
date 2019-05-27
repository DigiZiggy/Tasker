using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories.Identity;
using Domain.Identity;

namespace Contracts.BLL.App.Services.Identity
{
    public interface IAppRoleService : IBaseEntityService<AppRole>, IAppRoleRepository
    {
        
    }
}