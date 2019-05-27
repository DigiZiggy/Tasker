using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class SkillService : BaseEntityService<Skill, IAppUnitOfWork>, ISkillService
    {
        public SkillService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}