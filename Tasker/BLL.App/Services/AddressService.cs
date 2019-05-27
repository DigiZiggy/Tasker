using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class AddressService : BaseEntityService<Address, IAppUnitOfWork>, IAddressService
    {
        public AddressService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}