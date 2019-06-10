using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using ee.itcollege.sigrid.narep.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class HourlyRateRepository : BaseRepository<DAL.App.DTO.HourlyRate, Domain.HourlyRate, AppDbContext>, IHourlyRateRepository
    {
        public HourlyRateRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new HourlyRateMapper())
        {
        }
    }
}