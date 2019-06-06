using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories.Identity;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services.Identity
{
    public interface IAppUserService : IBaseEntityService<BLLAppDTO.Identity.AppUser>, IAppUserRepository<BLLAppDTO.Identity.AppUser>
    {
        
    }
}