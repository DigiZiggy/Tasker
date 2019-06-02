using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PaymentRepository : BaseRepository<Payment, AppDbContext>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<List<Payment>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Invoice)
                .ToListAsync();          
        }
        
        public async Task<List<Payment>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(p => p.Invoice)
                .Where(c => c.Invoice.AppUser.Id == userId).ToListAsync();
        }
        
        public async Task<Payment> FindAllIncludedAsync(params object[] id)
        {
            var payment = await base.FindAsync(id);

            if (payment != null)
            {
                await RepositoryDbContext.Entry(payment).Reference(p => p.Invoice).LoadAsync();
            }

            return payment;
        }
    }
}