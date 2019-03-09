using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {

        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }
        
        public virtual IEnumerable<TEntity> All()
        {
            return _dbSet.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual TEntity Find(params object[] id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<TEntity> FindAsync(params object[] id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Remove(params object[] id)
        {
            _dbSet.Remove(Find(id));
        }

        public virtual int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}