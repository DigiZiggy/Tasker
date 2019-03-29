using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserGroupRepository : BaseRepository<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<UserGroup>> AllAsync()
        {
            return await RepositoryDbSet
                .ToListAsync();         }
    }
}