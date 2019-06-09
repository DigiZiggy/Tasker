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

        public override async Task<BLL.App.DTO.UserSkill> FindAsync(params object[] id)
        {
            return UserSkillMapper.MapFromDAL(await Uow.UserSkills.FindAsync(id));
        }
    }
}