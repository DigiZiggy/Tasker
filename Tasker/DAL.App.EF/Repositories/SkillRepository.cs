using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class SkillRepository : BaseRepository<Skill, AppDbContext>, ISkillRepository
    {
        public SkillRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}