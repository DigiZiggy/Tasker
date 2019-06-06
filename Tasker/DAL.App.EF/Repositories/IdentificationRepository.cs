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
    public class IdentificationRepository : BaseRepository<DAL.App.DTO.Identification, Domain.Identification, AppDbContext>, IIdentificationRepository
    {
        public IdentificationRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new IdentificationMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.Identification>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(i => i.AppUser)
                .Select(e => IdentificationMapper.MapFromDomain(e)).ToListAsync(); 
        }
        
        public async Task<List<DAL.App.DTO.Identification>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(i => i.AppUser)
                .Where(c => c.AppUser.Id == userId)
                .Select(e => IdentificationMapper.MapFromDomain(e)).ToListAsync();

        }

        
        public async Task<DAL.App.DTO.Identification> FindAllIncludedAsync(params object[] id)
        {
            var identification = await base.FindAsync(id);

            if (identification != null)
            {
                await RepositoryDbContext.Entry(identification).Reference(i => i.AppUser).LoadAsync();
            }

            return identification;
        }

        public Task<Identification> FindForUserAsync(int id, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}