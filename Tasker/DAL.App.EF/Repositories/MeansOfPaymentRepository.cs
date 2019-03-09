using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class MeansOfPaymentRepository : BaseRepository<MeansOfPayment>, IMeansOfPaymentRepository
    {
        public MeansOfPaymentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}