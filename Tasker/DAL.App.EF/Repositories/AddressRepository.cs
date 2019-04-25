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

namespace DAL.App.EF.Repositories
{
    public class AddressRepository : BaseRepositoryAsync<Address>, IAddressRepository
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
        
        /// <summary>
        /// Get all the Addresses from db
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<AddressDTO>> GetAllWithAddressAsync()
        {          
            return await RepositoryDbSet
                .Select(a => new AddressDTO()
                {
                    Id = a.Id,
                    Street = a.Street,
                    District = a.District,
                    PostalCode = a.PostalCode
                })
                .ToListAsync();
        }
    }
}