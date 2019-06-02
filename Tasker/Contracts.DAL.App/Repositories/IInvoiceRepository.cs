using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IInvoiceRepository : IBaseRepositoryAsync<Invoice>
    {
        Task<Invoice> FindAllIncludedAsync(params object[] id);
        Task<List<Invoice>> AllForUserAsync(int userId);
    }
}