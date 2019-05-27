using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IReviewRepository : IBaseRepositoryAsync<Review>
    {
        Task<Review> FindAllIncludedAsync(params object[] id);      
    }
}