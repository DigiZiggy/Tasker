using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TaskerTaskRepository : BaseRepository<TaskerTask, AppDbContext>, ITaskerTaskRepository
    {
        public TaskerTaskRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<List<TaskerTask>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(t => t.Address)
                .ToListAsync();          
        }
        
        public async Task<TaskerTask> FindAllIncludedAsync(params object[] id)
        {
            var task = await base.FindAsync(id);

            if (task != null)
            {
                await RepositoryDbContext.Entry(task).Reference(t => t.Address).LoadAsync();
            }
            return task;
        }
    }
}