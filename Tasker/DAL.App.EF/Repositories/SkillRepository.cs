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
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<Skill>> AllAsync()
        {
            return await RepositoryDbSet
                .ToListAsync();         
        }
    }
}