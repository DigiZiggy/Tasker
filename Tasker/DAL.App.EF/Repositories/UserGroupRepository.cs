using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserGroupRepository : BaseRepository<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<UserGroup>> AllAsync()
        {
            return await RepositoryDbSet
                .ToListAsync();         }
    }
}