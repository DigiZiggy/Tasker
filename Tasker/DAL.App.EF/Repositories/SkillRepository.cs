using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Skill = DAL.App.DTO.Skill;

namespace DAL.App.EF.Repositories
{
    public class SkillRepository : BaseRepository<DAL.App.DTO.Skill, Domain.Skill, AppDbContext>, ISkillRepository
    {
        public SkillRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new SkillMapper())
        {
        }
        
//        public override async Task<Skill> FindAsync(params object[] id)
//        {
//            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
//            
//            var skill = await RepositoryDbSet.FindAsync(id);
//            if (skill != null)
//            {
//                await RepositoryDbContext.Entry(skill)
//                    .Reference(c => c.SkillName)
//                    .LoadAsync();
//                await RepositoryDbContext.Entry(skill)
//                    .Reference(c => c.Description)
//                    .LoadAsync();
//                
//                await RepositoryDbContext.Entry(skill.SkillName)
//                    .Collection(b => b.Translations)
//                    .Query()
//                    .Where(t => t.Culture == culture)
//                    .LoadAsync();
//                await RepositoryDbContext.Entry(skill.Description)
//                    .Collection(b => b.Translations)
//                    .Query()
//                    .Where(t => t.Culture == culture)
//                    .LoadAsync();
//            }
// 
//            return SkillMapper.MapFromDomain(skill);
//        }
//
//        public override Skill Update(Skill entity)
//        {
//            var entityInDb = RepositoryDbSet
//                .Include(m => m.SkillName)
//                .Include(m => m.Description)
//                .ThenInclude(t => t.Translations)
//                .FirstOrDefault(x => x.Id == entity.Id);
//
//            entityInDb.SkillName.SetTranslation(entity.SkillName);
//            entityInDb.Description.SetTranslation(entity.Description);
//       
//            return entity;
//        }
    }
}