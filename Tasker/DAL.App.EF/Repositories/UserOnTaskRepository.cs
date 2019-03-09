using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserOnTaskRepository : BaseRepository<UserOnTask>, IUserOnTaskRepository
    {
        public UserOnTaskRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}