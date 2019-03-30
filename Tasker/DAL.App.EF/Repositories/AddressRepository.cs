using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<Address>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(a => a.City)
                .ToListAsync();
        }

        public override async Task<Address> FindAsync(params object[] id)
        {
            var address = await base.FindAsync(id);

            if (address != null)
            {
                await RepositoryDbContext.Entry(address).Reference(a => a.City).LoadAsync();
            }

            return address;
        }
    }
}