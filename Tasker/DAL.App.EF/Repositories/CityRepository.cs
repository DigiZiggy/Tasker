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
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(IDataContext dataContext) : base(dataContext)
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
        
        /// <summary>
        /// Get all the Cities from db
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<CityDTO>> GetAllWithCityAsync()
        {          
            return await RepositoryDbSet
                .Select(c => new CityDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Comment = c.Comment
                })
                .ToListAsync();
        }
    }
}