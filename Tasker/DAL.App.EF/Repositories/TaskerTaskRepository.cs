using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TaskerTaskRepository : BaseRepository<DAL.App.DTO.TaskerTask, Domain.TaskerTask, AppDbContext>, ITaskerTaskRepository
    {
        public TaskerTaskRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new TaskerTaskMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.TaskerTask>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(t => t.Address)
                .Select(t => TaskerTaskMapper.MapFromDomain(t)).ToListAsync();          
        }
        
        public async Task<DAL.App.DTO.TaskerTask> FindAllIncludedAsync(params object[] id)
        {
            var task = await base.FindAsync(id);

            if (task != null)
            {
                await RepositoryDbContext.Entry(task).Reference(t => t.Address).LoadAsync();
            }
            return task;
        }

        public Task<TaskerTask> FindForUserAsync(int id, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}