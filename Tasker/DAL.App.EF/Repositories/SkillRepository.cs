using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(DbContext dbContext) : base(dbContext)
        {
        }
        
        public async Task<IEnumerable<Skill>> AllAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(a => a.AppUser)
                .Where(b => b.AppUserId == userId)
                .ToListAsync();
        }

        public override async Task<Skill> FindAsync(params object[] id)
        {
            var skill = await base.FindAsync(id);

            if (skill != null)
            {
                await RepositoryDbContext.Entry(skill).Reference(u => u.AppUser).LoadAsync();
            }
            return skill;
        }
    }
}