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

        public override async Task<IEnumerable<Skill>> AllAsync()
        {
            return await RepositoryDbSet
                .ToListAsync();         
        }
    }
}