using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ReviewRepository : BaseRepositoryAsync<Review>, IReviewRepository
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
        
        /// <summary>
        /// Get all the Reviews from db
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<ReviewDTO>> GetAllWithReviewAsync()
        {          
            return await RepositoryDbSet
                .Select(r => new ReviewDTO()
                {
                    Id = r.Id,
                    Rating = r.Rating,
                    Comment = r.Comment
                })
                .ToListAsync();
        }
    }
}