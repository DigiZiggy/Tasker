using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SkillRepository : BaseRepository<DAL.App.DTO.Skill, Domain.Skill, AppDbContext>, ISkillRepository
    {
        public SkillRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new SkillMapper())
        {
        }
    }
}