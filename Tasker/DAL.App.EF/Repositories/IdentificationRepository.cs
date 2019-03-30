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
    public class IdentificationRepository : BaseRepository<Identification>, IIdentificationRepository
    {
        public IdentificationRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<Identification>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(i => i.AppUser)
                .Include(i => i.IdentificationType)
                .Include(i => i.User)
                .ToListAsync();  
        }
        
        public override async Task<Identification> FindAsync(params object[] id)
        {
            var identification = await base.FindAsync(id);

            if (identification != null)
            {
                await RepositoryDbContext.Entry(identification).Reference(i => i.AppUser).LoadAsync();
                await RepositoryDbContext.Entry(identification).Reference(i => i.IdentificationType).LoadAsync();
                await RepositoryDbContext.Entry(identification).Reference(i => i.User).LoadAsync();

            }

            return identification;
        }
    }
}