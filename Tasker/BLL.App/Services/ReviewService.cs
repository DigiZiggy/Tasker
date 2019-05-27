using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class ReviewService : BaseEntityService<Review, IAppUnitOfWork>, IReviewService
    {
        public ReviewService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<Review> FindAllIncludedAsync(params object[] id)
        {
            return await Uow.Reviews.FindAllIncludedAsync(id);

        }
    }
}