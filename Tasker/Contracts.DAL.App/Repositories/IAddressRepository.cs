using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IAddressRepository : IBaseRepositoryAsync<Address, int>
    {
        
    }
}