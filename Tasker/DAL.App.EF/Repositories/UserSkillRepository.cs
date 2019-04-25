using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Task;

namespace DAL.App.EF.Repositories
{
    public class UserSkillRepository : BaseRepositoryAsync<UserSkill>, IUserSkillRepository
    {
        public UserSkillRepository(IDataContext dataContext) : base(dataContext)
        {
        }
        
        public override async Task<IEnumerable<UserSkill>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(a => a.AppUser)
                .Include(u => u.Skill)
                .Include(u => u.User)
                .ToListAsync();
        }
        
        public override async Task<UserSkill> FindAsync(params object[] id)
        {
            var userSkill = await base.FindAsync(id);

            if (userSkill != null)
            {
                await RepositoryDbContext.Entry(userSkill).Reference(u => u.AppUser).LoadAsync();
                await RepositoryDbContext.Entry(userSkill).Reference(u => u.Skill).LoadAsync();
                await RepositoryDbContext.Entry(userSkill).Reference(u => u.User).LoadAsync();
            }

            return userSkill;
        }
        
        /// <summary>
        /// Get all the User Skills from db
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<UserSkillDTO>> GetAllWithUserSkillAsync()
        {          
            return await RepositoryDbSet
                .Select(u => new UserSkillDTO()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Start = u.Start,
                    End = u.End,
                    Comment = u.Comment
                })
                .ToListAsync();
        }
    }
}