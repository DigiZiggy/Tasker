using BLL.App.Mappers;
using BLL.App.Mappers.Identity;
using BLL.Base.Services;
using Contracts.BLL.App.Services.Identity;
using Contracts.DAL.App;

namespace BLL.App.Services.Identity
{
    public class AppUserService : BaseEntityService<BLL.App.DTO.Identity.AppUser, DAL.App.DTO.Identity.AppUser, IAppUnitOfWork>, IAppUserService
    {
        public AppUserService(IAppUnitOfWork uow) : base(uow, new AppUserMapper())
        {
            ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Identity.AppUser, Domain.Identity.AppUser>();
        }
    }
}