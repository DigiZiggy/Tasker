using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;


namespace BLL.App.Services
{
    public class ReviewService : BaseEntityService<BLL.App.DTO.Review, DAL.App.DTO.Review, IAppUnitOfWork>, IReviewService
    {
        public ReviewService(IAppUnitOfWork uow) : base(uow, new ReviewMapper())
        {
            ServiceRepository = Uow.Reviews;
        }

        public async Task<BLL.App.DTO.Review> FindAllIncludedAsync(params object[] id)
        {
            return ReviewMapper.MapFromDAL(await Uow.Reviews.FindAllIncludedAsync(id));
        }
        
        public async Task<BLL.App.DTO.Review> FindForUserAsync(int id, int userId)
        {
            return ReviewMapper.MapFromDAL(await Uow.Reviews.FindForUserAsync(id, userId));
        }
        
        public async Task<List<BLL.App.DTO.Review>> AllForUserAsync(int userId)
        {
            return (await Uow.Reviews.AllForUserAsync(userId)).Select(e => ReviewMapper.MapFromDAL(e)).ToList();
        }
    }
}