using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.App.Repositories.Identity;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using DAL.App.EF.Mappers.Identity;
using ee.itcollege.sigrid.narep.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using AppUser = DAL.App.DTO.Identity.AppUser;

namespace DAL.App.EF.Repositories.Identity
{
    public class AppUserRepository : BaseRepository<DAL.App.DTO.Identity.AppUser, Domain.Identity.AppUser, AppDbContext>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new AppUserMapper())
        {
        }
        
//        public override async Task<DAL.App.DTO.Identity.AppUser> FindAsync(params object[] id)
//        {
//            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
//            
//            var appUser = await RepositoryDbSet.FindAsync(id);
//            if (appUser != null)
//            {
//                await RepositoryDbContext.Entry(appUser)
//                    .Reference(c => c.SelfDescription)
//                    .LoadAsync();
//                
//                await RepositoryDbContext.Entry(appUser.SelfDescription)
//                    .Collection(b => b.Translations)
//                    .Query()
//                    .Where(t => t.Culture == culture)
//                    .LoadAsync();
//            }
// 
//            return AppUserMapper.MapFromDomain(appUser);
//        }
//
//        public override AppUser Update(AppUser entity)
//        {
//            var entityInDb = RepositoryDbSet
//                .Include(m => m.SelfDescription)
//                .ThenInclude(t => t.Translations)
//                .FirstOrDefault(x => x.Id == entity.Id);
//
//            entityInDb.SelfDescription.SetTranslation(entity.SelfDescription);
//
//            return entity;
//        }
    }
}