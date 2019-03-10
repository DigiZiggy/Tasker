using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class IdentificationRepository : BaseRepository<Identification>, IIdentificationRepository
    {
        public IdentificationRepository(DbContext dbContext) : base(dbContext)
        {
        }
        
        public async Task<IEnumerable<Identification>> AllAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(a => a.AppUser)
                .Where(b => b.AppUserId == userId)
                .ToListAsync();
        }

        public override async Task<Identification> FindAsync(params object[] id)
        {
            var identification = await base.FindAsync(id);

            if (identification != null)
            {
                await RepositoryDbContext.Entry(identification).Reference(u => u.AppUser).LoadAsync();
            }
            return identification;
        }
    }
}