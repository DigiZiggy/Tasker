using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class UserSkillService : BaseEntityService<UserSkill, IAppUnitOfWork>, IUserSkillService
    {
        public UserSkillService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<UserSkill> FindAllIncludedAsync(params object[] id)
        {
            return await Uow.UserSkills.FindAllIncludedAsync(id);
        }
        
        public async Task<List<UserSkill>> AllForUserAsync(int userId)
        {
            return await Uow.UserSkills.AllForUserAsync(userId);
        }
    }
}