using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<User>> AllAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(a => a.AppUser)
                .Include(u => u.HourlyRate)
                .Include(u => u.UserType)
                .Where(b => b.AppUserId == userId)
                .ToListAsync();
        }


        public override async Task<User> FindAsync(params object[] id)
        {
            var user = await base.FindAsync(id);

            if (user != null)
            {
                await RepositoryDbContext.Entry(user).Reference(u => u.AppUser).LoadAsync();
                await RepositoryDbContext.Entry(user).Reference(u => u.HourlyRate).LoadAsync();
                await RepositoryDbContext.Entry(user).Reference(u => u.UserType).LoadAsync();
            }
            return user;
        }
    }
}