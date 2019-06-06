using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories.Identity;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services.Identity
{
    public interface IAppRoleService : IBaseEntityService<BLLAppDTO.Identity.AppRole>, IAppRoleRepository<BLLAppDTO.Identity.AppRole>
    {
        
    }
}