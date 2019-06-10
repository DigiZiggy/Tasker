using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.sigrid.narep.BLL.Base.Services;


namespace BLL.App.Services
{
    public class SkillService : BaseEntityService<BLL.App.DTO.Skill, DAL.App.DTO.Skill, IAppUnitOfWork>, ISkillService
    {
        public SkillService(IAppUnitOfWork uow) : base(uow, new SkillMapper())
        {
            ServiceRepository = Uow.Skills;
        }
    }
}