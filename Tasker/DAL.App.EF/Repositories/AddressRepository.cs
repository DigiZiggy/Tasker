using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class AddressRepository : BaseRepository<Address, AppDbContext>, IAddressRepository
    {
        public AddressRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}