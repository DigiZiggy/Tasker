using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using TaskerTask = DAL.App.DTO.TaskerTask;

namespace DAL.App.EF.Repositories
{
    public class TaskerTaskRepository : BaseRepository<DAL.App.DTO.TaskerTask, Domain.TaskerTask, AppDbContext>, ITaskerTaskRepository
    {
        public TaskerTaskRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new TaskerTaskMapper())
        {
        }
        
//        public override async Task<TaskerTask> FindAsync(params object[] id)
//        {
//            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
//            
//            var taskerTask = await RepositoryDbSet.FindAsync(id);
//            if (taskerTask != null)
//            {
//                await RepositoryDbContext.Entry(taskerTask)
//                    .Reference(c => c.TaskName)
//                    .LoadAsync();
//                await RepositoryDbContext.Entry(taskerTask)
//                    .Reference(c => c.Description)
//                    .LoadAsync();
//                
//                await RepositoryDbContext.Entry(taskerTask.TaskName)
//                    .Collection(b => b.Translations)
//                    .Query()
//                    .Where(t => t.Culture == culture)
//                    .LoadAsync();
//                await RepositoryDbContext.Entry(taskerTask.Description)
//                    .Collection(b => b.Translations)
//                    .Query()
//                    .Where(t => t.Culture == culture)
//                    .LoadAsync();
//            }
// 
//            return TaskerTaskMapper.MapFromDomain(taskerTask);
//        }
//
//        public override TaskerTask Update(TaskerTask entity)
//        {
//            var entityInDb = RepositoryDbSet
//                .Include(m => m.TaskName)
//                .Include(m => m.Description)
//                .ThenInclude(t => t.Translations)
//                .FirstOrDefault(x => x.Id == entity.Id);
//
//            entityInDb.TaskName.SetTranslation(entity.TaskName);
//            entityInDb.Description.SetTranslation(entity.Description);
//
//            return entity;
//        }
//        
//        public override async Task<List<DAL.App.DTO.TaskerTask>> AllAsync()
//        {
//            return await RepositoryDbSet
//                .Include(m => m.TaskName)
//                .ThenInclude(t => t.Translations)
//                .Include(m => m.Description)
//                .ThenInclude(t => t.Translations)
//                .Include(t => t.Address)
//                .Select(t => TaskerTaskMapper.MapFromDomain(t)).ToListAsync();          
//        }
    }
}