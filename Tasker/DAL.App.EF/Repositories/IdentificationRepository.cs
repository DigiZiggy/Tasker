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
using Identification = DAL.App.DTO.Identification;


namespace DAL.App.EF.Repositories
{
    public class IdentificationRepository : BaseRepository<DAL.App.DTO.Identification, Domain.Identification, AppDbContext>, IIdentificationRepository
    {
        public IdentificationRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new IdentificationMapper())
        {
        }
        
//        public override async Task<Identification> FindAsync(params object[] id)
//        {
//            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
//            
//            var identification = await RepositoryDbSet.FindAsync(id);
//            if (identification != null)
//            {
//                await RepositoryDbContext.Entry(identification)
//                    .Reference(c => c.Comment)
//                    .LoadAsync();
//                
//                await RepositoryDbContext.Entry(identification.Comment)
//                    .Collection(b => b.Translations)
//                    .Query()
//                    .Where(t => t.Culture == culture)
//                    .LoadAsync();
//            }
// 
//            return IdentificationMapper.MapFromDomain(identification);
//        }
//
//        public override Identification Update(Identification entity)
//        {
//            var entityInDb = RepositoryDbSet
//                .Include(m => m.Comment)
//                .ThenInclude(t => t.Translations)
//                .FirstOrDefault(x => x.Id == entity.Id);
//
//            entityInDb.Comment.SetTranslation(entity.Comment);
//
//            return entity;
//        }
//        
//        public override async Task<List<DAL.App.DTO.Identification>> AllAsync()
//        {
//            return await RepositoryDbSet
//                .Include(m => m.Comment)
//                .ThenInclude(t => t.Translations)
//                .Include(i => i.AppUser)
//                .Select(e => IdentificationMapper.MapFromDomain(e)).ToListAsync(); 
//        }
    }
}