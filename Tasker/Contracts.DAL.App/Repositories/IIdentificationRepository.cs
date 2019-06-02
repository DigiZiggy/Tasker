using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IIdentificationRepository : IBaseRepositoryAsync<Identification>
    {
        Task<Identification> FindAllIncludedAsync(params object[] id);
        Task<List<Identification>> AllForUserAsync(int userId);
    }
}