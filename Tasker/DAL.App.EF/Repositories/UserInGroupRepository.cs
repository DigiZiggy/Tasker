using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserInGroupRepository : BaseRepositoryAsync<UserInGroup>, IUserInGroupRepository
    {
        public UserInGroupRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<UserInGroup>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(u => u.User)
                .Include(u => u.UserGroup)
                .ToListAsync();          
        }
        
        public override async Task<UserInGroup> FindAsync(params object[] id)
        {
            var userInGroup = await base.FindAsync(id);

            if (userInGroup != null)
            {
                await RepositoryDbContext.Entry(userInGroup).Reference(u => u.User).LoadAsync();
                await RepositoryDbContext.Entry(userInGroup).Reference(u => u.UserGroup).LoadAsync();
            }

            return userInGroup;
        }
    }
}