using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class HourlyRateRepository : BaseRepository<HourlyRate>, IHourlyRateRepository
    {
        public HourlyRateRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}