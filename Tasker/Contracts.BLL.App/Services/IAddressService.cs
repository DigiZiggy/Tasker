using Contracts.DAL.App.Repositories;
using ee.itcollege.sigrid.narep.Contracts.BLL.Base.Services;
using BLLAppDTO = BLL.App.DTO;


namespace Contracts.BLL.App.Services
{
    public interface IAddressService : IBaseEntityService<BLLAppDTO.Address>, IAddressRepository<BLLAppDTO.Address>
    {
        
    }
}