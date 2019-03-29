using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserOnAddressRepository : BaseRepository<UserOnAddress>, IUserOnAddressRepository
    {
        public UserOnAddressRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<UserOnAddress>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(u => u.Address)
                .Include(u => u.AppUser)
                .Include(u => u.User)
                .ToListAsync();  
        }
        
        public override async Task<UserOnAddress> FindAsync(params object[] id)
        {
            var userOnAddress = await base.FindAsync(id);

            if (userOnAddress != null)
            {
                await RepositoryDbContext.Entry(userOnAddress).Reference(u => u.Address).LoadAsync();
                await RepositoryDbContext.Entry(userOnAddress).Reference(u => u.User).LoadAsync();
                await RepositoryDbContext.Entry(userOnAddress).Reference(u => u.AppUser).LoadAsync();
            }

            return userOnAddress;
        }
    }
}