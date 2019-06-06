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
    public class UserSkillRepository : BaseRepository<DAL.App.DTO.UserSkill, Domain.UserSkill, AppDbContext>, IUserSkillRepository
    {
        public UserSkillRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new UserSkillMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.UserSkill>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(a => a.AppUser)
                .Include(u => u.Skill)
                .Select(e => UserSkillMapper.MapFromDomain(e)).ToListAsync();
        }
        
        public async Task<List<DAL.App.DTO.UserSkill>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(u => u.Skill)
                .Include(u => u.AppUser)
                .Where(c => c.AppUser.Id == userId)
                .Select(e => UserSkillMapper.MapFromDomain(e)).ToListAsync();

        }
        
        public async Task<DAL.App.DTO.UserSkill> FindAllIncludedAsync(params object[] id)
        {
            var userSkill = await base.FindAsync(id);

            if (userSkill != null)
            {
                await RepositoryDbContext.Entry(userSkill).Reference(u => u.AppUser).LoadAsync();
                await RepositoryDbContext.Entry(userSkill).Reference(u => u.Skill).LoadAsync();
            }
            return userSkill;
        }

        public Task<UserSkill> FindForUserAsync(int id, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}