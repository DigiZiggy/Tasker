using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DAL.App.EF.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(IDataContext dataContext) : base(dataContext)
        {
        }
        public override async Task<IEnumerable<Country>> AllAsync()
        {
            return await RepositoryDbSet
                .ToListAsync();
        }
       
    }
}