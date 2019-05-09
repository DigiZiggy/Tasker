using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ReviewRepository : BaseRepositoryAsync<Review>, IReviewRepository
    {
        public ReviewRepository(IDataContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<IEnumerable<Review>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(r => r.AppUser)
                .ToListAsync();          
        }
        
        public async Task<Review> FindAllIncludedAsync(params object[] id)
        {
            var review = await base.FindAsync(id);

            if (review != null)
            {
                await RepositoryDbContext.Entry(review).Reference(r => r.AppUser).LoadAsync();
            }

            return review;
        }
    }
}