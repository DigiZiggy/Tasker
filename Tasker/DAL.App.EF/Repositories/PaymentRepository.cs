using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PaymentRepository : BaseRepository<DAL.App.DTO.Payment, Domain.Payment, AppDbContext>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new PaymentMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.Payment>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.Invoice)
                .Select(p => PaymentMapper.MapFromDomain(p)).ToListAsync();          
        }
        
        public async Task<List<DAL.App.DTO.Payment>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(p => p.Invoice)
                .Where(c => c.Invoice.AppUser.Id == userId)
                .Select(p => PaymentMapper.MapFromDomain(p)).ToListAsync();

        }
        
        public async Task<DAL.App.DTO.Payment> FindAllIncludedAsync(params object[] id)
        {
            var payment = await base.FindAsync(id);

            if (payment != null)
            {
                await RepositoryDbContext.Entry(payment).Reference(p => p.Invoice).LoadAsync();
            }

            return payment;
        }

        public Task<Payment> FindForUserAsync(int id, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}