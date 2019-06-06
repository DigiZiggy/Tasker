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
    public class UserTaskRepository : BaseRepository<DAL.App.DTO.UserTask, Domain.UserTask, AppDbContext>, IUserTaskRepository
    {
        public UserTaskRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new UserTaskMapper())
        {
        }
               
        public override async Task<List<DAL.App.DTO.UserTask>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(u => u.TaskGiver)
                .Include(u => u.Tasker)
                .Select(e => UserTaskMapper.MapFromDomain(e)).ToListAsync(); 
        }
        
        public async Task<List<DAL.App.DTO.UserTask>> AllForTaskGiverAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(u => u.TaskGiver)
                .Include(u => u.Tasker)
                .Include(t => t.TaskerTask)
                .Where(c => c.TaskGiver.Id == userId)
                .Select(e => UserTaskMapper.MapFromDomain(e)).ToListAsync();
        }
        
        public async Task<List<DAL.App.DTO.UserTask>> AllForTaskerAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(u => u.TaskGiver)
                .Include(u => u.Tasker)
                .Include(t => t.TaskerTask)
                .Where(c => c.Tasker.Id == userId)
                .Select(e => UserTaskMapper.MapFromDomain(e)).ToListAsync();
        }
        
        public async Task<DAL.App.DTO.UserTask> FindAllIncludedAsync(params object[] id)
        {
            var userTask = await base.FindAsync(id);

            if (userTask != null)
            {
                await RepositoryDbContext.Entry(userTask).Reference(u => u.TaskGiver).LoadAsync();
                await RepositoryDbContext.Entry(userTask).Reference(u => u.Tasker).LoadAsync();
            }

            return userTask;
        }

        public Task<UserTask> FindForUserAsync(int id, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}