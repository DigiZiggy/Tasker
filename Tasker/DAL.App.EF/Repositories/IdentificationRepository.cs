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
    public class IdentificationRepository : BaseRepository<Identification, AppDbContext>, IIdentificationRepository
    {
        public IdentificationRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<List<Identification>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(i => i.AppUser)
                .ToListAsync();  
        }
        
        public async Task<List<Identification>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(i => i.AppUser)
                .Where(c => c.AppUser.Id == userId).ToListAsync();
        }

        
        public async Task<Identification> FindAllIncludedAsync(params object[] id)
        {
            var identification = await base.FindAsync(id);

            if (identification != null)
            {
                await RepositoryDbContext.Entry(identification).Reference(i => i.AppUser).LoadAsync();
            }

            return identification;
        }
    }
}