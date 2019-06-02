using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class UserOnAddressService : BaseEntityService<UserOnAddress, IAppUnitOfWork>, IUserOnAddressService
    {
        public UserOnAddressService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<UserOnAddress> FindAllIncludedAsync(params object[] id)
        {
            return await Uow.UserOnAddresses.FindAllIncludedAsync(id);
        }
        
        public async Task<List<UserOnAddress>> AllForUserAsync(int userId)
        {
            return await Uow.UserOnAddresses.AllForUserAsync(userId);
        }
    }
}