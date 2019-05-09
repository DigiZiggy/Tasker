using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IIdentificationRepository : IBaseRepositoryAsync<Identification, int>
    {
        Task<Identification> FindAllIncludedAsync(params object[] id);      
    }
}