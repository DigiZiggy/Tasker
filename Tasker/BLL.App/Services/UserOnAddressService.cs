using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;


namespace BLL.App.Services
{
    public class UserOnAddressService : BaseEntityService<BLL.App.DTO.UserOnAddress, DAL.App.DTO.UserOnAddress, IAppUnitOfWork>, IUserOnAddressService
    {
        public UserOnAddressService(IAppUnitOfWork uow) : base(uow, new UserOnAddressMapper())
        {
            ServiceRepository = Uow.BaseRepository<DAL.App.DTO.UserOnAddress, Domain.UserOnAddress>();
        }

        public async Task<BLL.App.DTO.UserOnAddress> FindAllIncludedAsync(params object[] id)
        {
            return UserOnAddressMapper.MapFromDAL(await Uow.UserOnAddresses.FindAllIncludedAsync(id));
        }
        
        public async Task<BLL.App.DTO.UserOnAddress> FindForUserAsync(int id, int userId)
        {
            return UserOnAddressMapper.MapFromDAL(await Uow.UserOnAddresses.FindForUserAsync(id, userId));
        }
        
        public async Task<List<BLL.App.DTO.UserOnAddress>> AllForUserAsync(int userId)
        {
            return (await Uow.UserOnAddresses.AllForUserAsync(userId)).Select(e => UserOnAddressMapper.MapFromDAL(e)).ToList();
        }
    }
}