using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PriceListRepository : BaseRepository<PriceList>, IPriceListRepository
    {
        public PriceListRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}