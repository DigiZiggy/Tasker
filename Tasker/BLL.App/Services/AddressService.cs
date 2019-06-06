using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;


namespace BLL.App.Services
{
    public class AddressService : BaseEntityService<BLL.App.DTO.Address, DAL.App.DTO.Address, IAppUnitOfWork>, IAddressService
    {
        public AddressService(IAppUnitOfWork uow) : base(uow, new AddressMapper())
        {
            ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Address, Domain.Address>();
        }
    }
}
