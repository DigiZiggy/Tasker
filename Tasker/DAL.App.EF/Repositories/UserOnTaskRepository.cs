using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserOnTaskRepository : BaseRepositoryAsync<UserOnTask>, IUserOnTaskRepository
    {
        public UserOnTaskRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<UserOnTask>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(u => u.AppUser)
                .Include(u => u.Task)
                .Include(u => u.TaskGiver)
                .Include(u => u.Tasker)
                .ToListAsync(); 
        }
        
        public override async Task<UserOnTask> FindAsync(params object[] id)
        {
            var userOnTask = await base.FindAsync(id);

            if (userOnTask != null)
            {
                await RepositoryDbContext.Entry(userOnTask).Reference(u => u.Task).LoadAsync();
                await RepositoryDbContext.Entry(userOnTask).Reference(u => u.AppUser).LoadAsync();
                await RepositoryDbContext.Entry(userOnTask).Reference(u => u.TaskGiver).LoadAsync();
                await RepositoryDbContext.Entry(userOnTask).Reference(u => u.Tasker).LoadAsync();
            }

            return userOnTask;
        }
    }
}