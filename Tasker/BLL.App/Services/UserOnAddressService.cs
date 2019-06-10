using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.sigrid.narep.BLL.Base.Services;


namespace BLL.App.Services
{
    public class UserOnAddressService : BaseEntityService<BLL.App.DTO.UserOnAddress, DAL.App.DTO.UserOnAddress, IAppUnitOfWork>, IUserOnAddressService
    {
        public UserOnAddressService(IAppUnitOfWork uow) : base(uow, new UserOnAddressMapper())
        {
            ServiceRepository = Uow.UserOnAddresses;
        }

        public override async Task<BLL.App.DTO.UserOnAddress> FindAsync(params object[] id)
        {
            return UserOnAddressMapper.MapFromDAL(await Uow.UserOnAddresses.FindAsync(id));
        }

    }
}