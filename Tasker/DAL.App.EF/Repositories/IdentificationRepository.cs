using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class IdentificationRepository : BaseRepositoryAsync<Identification>, IIdentificationRepository
    {
        public IdentificationRepository(IDataContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<IEnumerable<Identification>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(i => i.AppUser)
                .ToListAsync();  
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