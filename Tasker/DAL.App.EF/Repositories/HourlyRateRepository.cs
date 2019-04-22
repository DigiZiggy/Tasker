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
        
        /// <summary>
        /// Get all the Hourly Rates from db
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<HourlyRateDTO>> GetAllWithHourlyRateAsync()
        {          
            return await RepositoryDbSet
                .Select(h => new HourlyRateDTO()
                {
                    Id = h.Id,
                    HourRate = h.HourRate,
                    Start = h.Start,
                    End = h.End
                })
                .ToListAsync();
        }
    }
}