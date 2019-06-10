using Contracts.DAL.App.Repositories.Identity;
using ee.itcollege.sigrid.narep.Contracts.BLL.Base.Services;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services.Identity
{
    public interface IAppUserService : IBaseEntityService<BLLAppDTO.Identity.AppUser>, IAppUserRepository<BLLAppDTO.Identity.AppUser>
    {
        
    }
}