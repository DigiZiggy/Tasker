using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<City>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(c => c.Country)
                .ToListAsync();
        }
        
        public override async Task<City> FindAsync(params object[] id)
        {
            var city = await base.FindAsync(id);

            if (city != null)
            {
                await RepositoryDbContext.Entry(city).Reference(c => c.Country).LoadAsync();
            }

            return city;
        }
    }
}