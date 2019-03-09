using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TaskTypeRepository : BaseRepository<TaskType>, ITaskTypeRepository
    {
        public TaskTypeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}