using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IAddressRepository : IBaseRepositoryAsync<Address>
    {
        Task<IEnumerable<AddressDTO>> GetAllWithAddressAsync();
    }
}