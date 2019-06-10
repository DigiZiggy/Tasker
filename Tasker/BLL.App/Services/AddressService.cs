using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.sigrid.narep.BLL.Base.Services;


namespace BLL.App.Services
{
    public class AddressService : BaseEntityService<BLL.App.DTO.Address, DAL.App.DTO.Address, IAppUnitOfWork>, IAddressService
    {
        public AddressService(IAppUnitOfWork uow) : base(uow, new AddressMapper())
        {
            ServiceRepository = Uow.Addresses;
        }
    }
}
