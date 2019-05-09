using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IPaymentRepository : IBaseRepositoryAsync<Payment, int>
    {
        Task<Payment> FindAllIncludedAsync(params object[] id);      
        
    }
}