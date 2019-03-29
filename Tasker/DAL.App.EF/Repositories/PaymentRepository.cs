using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Payment>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Invoice)
                .Include(p => p.MeansOfPayment)
                .ToListAsync();          
        }
        
        public override async Task<Payment> FindAsync(params object[] id)
        {
            var payment = await base.FindAsync(id);

            if (payment != null)
            {
                await RepositoryDbContext.Entry(payment).Reference(p => p.Invoice).LoadAsync();
                await RepositoryDbContext.Entry(payment).Reference(p => p.MeansOfPayment).LoadAsync();
            }

            return payment;
        }
    }
}