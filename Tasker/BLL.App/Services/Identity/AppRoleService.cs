using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.App.Mappers.Identity;
using Contracts.BLL.App.Services.Identity;
using Contracts.DAL.App;
using ee.itcollege.sigrid.narep.BLL.Base.Services;


namespace BLL.App.Services.Identity
{
    public class AppRoleService : BaseEntityService<BLL.App.DTO.Identity.AppRole, DAL.App.DTO.Identity.AppRole, IAppUnitOfWork>, IAppRoleService
    {
        public AppRoleService(IAppUnitOfWork uow) : base(uow, new AppRoleMapper())
        {
            ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Identity.AppRole, Domain.Identity.AppRole>();
        }
    }
}