using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<Review>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(r => r.AppUser)
                .Include(r => r.Task)
                .ToListAsync();          
        }
        
        public override async Task<Review> FindAsync(params object[] id)
        {
            var review = await base.FindAsync(id);

            if (review != null)
            {
                await RepositoryDbContext.Entry(review).Reference(r => r.AppUser).LoadAsync();
                await RepositoryDbContext.Entry(review).Reference(r => r.Task).LoadAsync();
            }

            return review;
        }
    }
}