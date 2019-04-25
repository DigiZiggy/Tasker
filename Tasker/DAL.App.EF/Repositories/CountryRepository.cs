using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DAL.App.EF.Repositories
{
    public class CountryRepository : BaseRepositoryAsync<Country>, ICountryRepository
    {
        public CountryRepository(IDataContext dataContext) : base(dataContext)
        {
        }
        public override async Task<IEnumerable<Country>> AllAsync()
        {
            return await RepositoryDbSet
                .ToListAsync();
        }
        
        /// <summary>
        /// Get all the Countries from db
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<CountryDTO>> GetAllWithCountryAsync()
        {          
            return await RepositoryDbSet
                .Select(c => new CountryDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    CountryCode = c.CountryCode
                })
                .ToListAsync();
        }
       
    }
}