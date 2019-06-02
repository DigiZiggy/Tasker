using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserSkillRepository : BaseRepository<UserSkill, AppDbContext>, IUserSkillRepository
    {
        public UserSkillRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<List<UserSkill>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(a => a.AppUser)
                .Include(u => u.Skill)
                .ToListAsync();
        }
        
        public async Task<List<UserSkill>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(u => u.Skill)
                .Include(u => u.AppUser)
                .Where(c => c.AppUser.Id == userId).ToListAsync();
        }
        
        public async Task<UserSkill> FindAllIncludedAsync(params object[] id)
        {
            var userSkill = await base.FindAsync(id);

            if (userSkill != null)
            {
                await RepositoryDbContext.Entry(userSkill).Reference(u => u.AppUser).LoadAsync();
                await RepositoryDbContext.Entry(userSkill).Reference(u => u.Skill).LoadAsync();
            }
            return userSkill;
        }
    }
}