using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PriceRepository : BaseRepository<Price>, IPriceRepository
    {
        public PriceRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<Price>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.PriceList)
                .ToListAsync();   
        }
        
        public override async Task<Price> FindAsync(params object[] id)
        {
            var price = await base.FindAsync(id);

            if (price != null)
            {
                await RepositoryDbContext.Entry(price).Reference(p => p.PriceList).LoadAsync();
            }

            return price;
        }
    }
}