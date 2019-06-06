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
    public class UserOnAddressRepository : BaseRepository<DAL.App.DTO.UserOnAddress, Domain.UserOnAddress, AppDbContext>, IUserOnAddressRepository
    {
        public UserOnAddressRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new UserOnAddressMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.UserOnAddress>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(u => u.Address)
                .Include(u => u.AppUser)
                .Select(e => UserOnAddressMapper.MapFromDomain(e)).ToListAsync(); 
        }
        
        public async Task<List<DAL.App.DTO.UserOnAddress>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(u => u.Address)
                .Include(u => u.AppUser)
                .Where(c => c.AppUser.Id == userId)
                .Select(e => UserOnAddressMapper.MapFromDomain(e)).ToListAsync();

        }

        public async Task<DAL.App.DTO.UserOnAddress> FindAllIncludedAsync(params object[] id)
        {
            var userOnAddress = await base.FindAsync(id);

            if (userOnAddress != null)
            {
                await RepositoryDbContext.Entry(userOnAddress).Reference(u => u.Address).LoadAsync();
                await RepositoryDbContext.Entry(userOnAddress).Reference(u => u.AppUser).LoadAsync();
            }

            return userOnAddress;
        }

        public Task<UserOnAddress> FindForUserAsync(int id, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}