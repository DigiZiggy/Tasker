using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.sigrid.narep.BLL.Base.Services;


namespace BLL.App.Services
{
    public class ReviewService : BaseEntityService<BLL.App.DTO.Review, DAL.App.DTO.Review, IAppUnitOfWork>, IReviewService
    {
        public ReviewService(IAppUnitOfWork uow) : base(uow, new ReviewMapper())
        {
            ServiceRepository = Uow.Reviews;
        }

        public override async Task<BLL.App.DTO.Review> FindAsync(params object[] id)
        {
            return ReviewMapper.MapFromDAL(await Uow.Reviews.FindAsync(id));
        }
    }
}