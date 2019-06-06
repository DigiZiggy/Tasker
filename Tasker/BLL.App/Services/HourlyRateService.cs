using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;


namespace BLL.App.Services
{
    public class HourlyRateService : BaseEntityService<BLL.App.DTO.HourlyRate, DAL.App.DTO.HourlyRate, IAppUnitOfWork>, IHourlyRateService
    {
        public HourlyRateService(IAppUnitOfWork uow) : base(uow, new HourlyRateMapper())
        {
            ServiceRepository = Uow.BaseRepository<DAL.App.DTO.HourlyRate, Domain.HourlyRate>();
        }
    }
}