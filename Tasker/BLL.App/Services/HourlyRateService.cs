using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.sigrid.narep.BLL.Base.Services;


namespace BLL.App.Services
{
    public class HourlyRateService : BaseEntityService<BLL.App.DTO.HourlyRate, DAL.App.DTO.HourlyRate, IAppUnitOfWork>, IHourlyRateService
    {
        public HourlyRateService(IAppUnitOfWork uow) : base(uow, new HourlyRateMapper())
        {
            ServiceRepository = Uow.HourlyRates;
        }
    }
}