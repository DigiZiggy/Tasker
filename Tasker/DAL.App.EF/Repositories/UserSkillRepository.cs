using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserSkillRepository : BaseRepository<UserSkill>, IUserSkillRepository
    {
        public UserSkillRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}