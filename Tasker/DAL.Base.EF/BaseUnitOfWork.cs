using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF
{
    public class BaseUnitOfWork : IUnitOfWork
    {
        protected readonly DbContext UOWDbContext;

        public BaseUnitOfWork(DbContext dbContext)
        {
            UOWDbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await UOWDbContext.SaveChangesAsync();
        }

        public IBaseRepositoryAsync<TEntity> BaseRepository<TEntity>() where TEntity : class, IBaseEntity, new()
        {
            throw new System.NotImplementedException();
        }
    }
}
