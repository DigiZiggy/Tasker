using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Task;

namespace DAL.App.EF.Repositories
{
    public class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
        public TaskRepository(DbContext dbContext) : base(dbContext)
        {
        }       

        public async Task<IEnumerable<Task>> AllAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(a => a.AppUser)
                .Where(b => b.AppUserId == userId)
                .ToListAsync();
        }

        public override async Task<Task> FindAsync(params object[] id)
        {
            var task = await base.FindAsync(id);

            if (task != null)
            {
                await RepositoryDbContext.Entry(task).Reference(u => u.AppUser).LoadAsync();
            }
            return task;
        }
    }
}