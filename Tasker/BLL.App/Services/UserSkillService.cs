using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;


namespace BLL.App.Services
{
    public class UserSkillService : BaseEntityService<BLL.App.DTO.UserSkill, DAL.App.DTO.UserSkill, IAppUnitOfWork>, IUserSkillService
    {
        public UserSkillService(IAppUnitOfWork uow) : base(uow, new UserSkillMapper())
        {
            ServiceRepository = Uow.UserSkills;
        }

        public async Task<BLL.App.DTO.UserSkill> FindAllIncludedAsync(params object[] id)
        {
            return UserSkillMapper.MapFromDAL(await Uow.UserSkills.FindAllIncludedAsync(id));
        }
        
        public async Task<BLL.App.DTO.UserSkill> FindForUserAsync(int id, int userId)
        {
            return UserSkillMapper.MapFromDAL(await Uow.UserSkills.FindForUserAsync(id, userId));
        }
        
        public async Task<List<BLL.App.DTO.UserSkill>> AllForUserAsync(int userId)
        {
            return (await Uow.UserSkills.AllForUserAsync(userId)).Select(e => UserSkillMapper.MapFromDAL(e)).ToList();
        }
    }
}