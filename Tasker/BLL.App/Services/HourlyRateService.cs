using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class HourlyRateService : BaseEntityService<HourlyRate, IAppUnitOfWork>, IHourlyRateService
    {
        public HourlyRateService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}