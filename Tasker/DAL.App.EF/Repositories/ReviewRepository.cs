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
    public class ReviewRepository : BaseRepository<Review, AppDbContext>, IReviewRepository
    {
        public ReviewRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<List<Review>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(r => r.ReviewReceiver)
                .Include(r => r.ReviewGiver)
                .ToListAsync();          
        }
        
        public async Task<List<Review>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(r => r.ReviewReceiver)
                .Include(r => r.ReviewGiver)
                .ToListAsync();
        }
        
        public async Task<Review> FindAllIncludedAsync(params object[] id)
        {
            var review = await base.FindAsync(id);

            if (review != null)
            {
                await RepositoryDbContext.Entry(review).Reference(r => r.ReviewReceiver).LoadAsync();
                await RepositoryDbContext.Entry(review).Reference(r => r.ReviewGiver).LoadAsync();
            }

            return review;
        }
    }
}