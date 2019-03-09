using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
        public TaskRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}