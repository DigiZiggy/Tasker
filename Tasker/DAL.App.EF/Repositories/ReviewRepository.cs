using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using ee.itcollege.sigrid.narep.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Review = DAL.App.DTO.Review;

namespace DAL.App.EF.Repositories
{
    public class ReviewRepository : BaseRepository<DAL.App.DTO.Review, Domain.Review, AppDbContext>, IReviewRepository
    {
        public ReviewRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new ReviewMapper())
        {
        }
        
        public override async Task<Review> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var review = await RepositoryDbSet.FindAsync(id);
            if (review != null)
            {
                await RepositoryDbContext.Entry(review)
                    .Reference(c => c.ReviewComment)
                    .LoadAsync();
                
                await RepositoryDbContext.Entry(review.ReviewComment)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
 
            return ReviewMapper.MapFromDomain(review);
        }

        public override Review Update(Review entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(m => m.ReviewComment)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);

            entityInDb.ReviewComment.SetTranslation(entity.ReviewComment);

            return entity;
        }
        
        public override async Task<List<DAL.App.DTO.Review>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(m => m.ReviewComment)
                .ThenInclude(t => t.Translations)
                .Include(r => r.ReviewReceiver)
                .Include(r => r.ReviewGiver)
                .Select(e => ReviewMapper.MapFromDomain(e)).ToListAsync();         
        }
    }
}