using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IUserOnAddressRepository : IBaseRepositoryAsync<UserOnAddress>
    {
        Task<UserOnAddress> FindAllIncludedAsync(params object[] id);      
    }
}