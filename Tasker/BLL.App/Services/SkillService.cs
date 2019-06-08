using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;


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