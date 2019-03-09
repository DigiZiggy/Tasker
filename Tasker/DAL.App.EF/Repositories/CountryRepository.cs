using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DAL.App.EF.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<User> All()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> AllAsync()
        {
            throw new System.NotImplementedException();
        }

        public User Find(params object[] id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindAsync(params object[] id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        public User Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}