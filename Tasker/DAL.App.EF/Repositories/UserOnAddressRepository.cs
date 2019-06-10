using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using ee.itcollege.sigrid.narep.DAL.Base.EF.Repositories;
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
    }
}