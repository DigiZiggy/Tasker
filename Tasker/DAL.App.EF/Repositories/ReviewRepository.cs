using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ReviewRepository : BaseRepository<DAL.App.DTO.Review, Domain.Review, AppDbContext>, IReviewRepository
    {
        public ReviewRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new ReviewMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.Review>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(r => r.ReviewReceiver)
                .Include(r => r.ReviewGiver)
                .Select(e => ReviewMapper.MapFromDomain(e)).ToListAsync();         
        }
        
        public async Task<List<DAL.App.DTO.Review>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(r => r.ReviewReceiver)
                .Include(r => r.ReviewGiver)
                .Select(e => ReviewMapper.MapFromDomain(e)).ToListAsync();         
        }
        
        public async Task<DAL.App.DTO.Review> FindAllIncludedAsync(params object[] id)
        {
            var review = await base.FindAsync(id);

            if (review != null)
            {
                await RepositoryDbContext.Entry(review).Reference(r => r.ReviewReceiver).LoadAsync();
                await RepositoryDbContext.Entry(review).Reference(r => r.ReviewGiver).LoadAsync();
            }

            return review;
        }

        public Task<Review> FindForUserAsync(int id, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}