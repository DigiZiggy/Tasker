using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserTaskRepository : BaseRepository<UserTask, AppDbContext>, IUserTaskRepository
    {
        public UserTaskRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
               
        public override async Task<List<UserTask>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(u => u.TaskGiver)
                .Include(u => u.Tasker)
                .ToListAsync(); 
        }
        
        public async Task<UserTask> FindAllIncludedAsync(params object[] id)
        {
            var userTask = await base.FindAsync(id);

            if (userTask != null)
            {
                await RepositoryDbContext.Entry(userTask).Reference(u => u.TaskGiver).LoadAsync();
                await RepositoryDbContext.Entry(userTask).Reference(u => u.Tasker).LoadAsync();
            }

            return userTask;
        }
    }
}