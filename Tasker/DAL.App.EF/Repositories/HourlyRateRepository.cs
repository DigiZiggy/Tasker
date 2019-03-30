using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class HourlyRateRepository : BaseRepository<HourlyRate>, IHourlyRateRepository
    {
        public HourlyRateRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<HourlyRate>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(h => h.PriceList)
                .ToListAsync();        
        }
        
        public override async Task<HourlyRate> FindAsync(params object[] id)
        {
            var hourlyRate = await base.FindAsync(id);

            if (hourlyRate != null)
            {
                await RepositoryDbContext.Entry(hourlyRate).Reference(h => h.PriceList).LoadAsync();
            }

            return hourlyRate;
        }
    }
}