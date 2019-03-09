using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class IdentificationRepository : BaseRepository<Identification>, IIdentificationRepository
    {
        public IdentificationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}