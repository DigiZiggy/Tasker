using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserTypeRepository : BaseRepository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<UserType>> AllAsync()
        {
            return await RepositoryDbSet
                .ToListAsync(); 
        }
    }
}