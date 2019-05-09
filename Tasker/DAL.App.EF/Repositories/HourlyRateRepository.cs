using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class HourlyRateRepository : BaseRepositoryAsync<HourlyRate>, IHourlyRateRepository
    {
        public HourlyRateRepository(IDataContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}