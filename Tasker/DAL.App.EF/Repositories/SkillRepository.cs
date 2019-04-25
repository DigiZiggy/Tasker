using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SkillRepository : BaseRepositoryAsync<Skill>, ISkillRepository
    {
        public SkillRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<Skill>> AllAsync()
        {
            return await RepositoryDbSet
                .ToListAsync();         
        }
        
        /// <summary>
        /// Get all the Skills from db
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<SkillDTO>> GetAllWithSkillAsync()
        {          
            return await RepositoryDbSet
                .Select(s => new SkillDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Comment = s.Comment
                })
                .ToListAsync();
        }
    }
}