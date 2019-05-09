using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class SkillRepository : BaseRepositoryAsync<Skill>, ISkillRepository
    {
        public SkillRepository(IDataContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}