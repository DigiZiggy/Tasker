using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(IDataContext dataContext) : base(dataContext)
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
        
        /// <summary>
        /// Get all the Payments from db
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<PaymentDTO>> GetAllWithPaymentAsync()
        {          
            return await RepositoryDbSet
                .Select(p => new PaymentDTO()
                {
                    Id = p.Id,
                    PaymentCode = p.PaymentCode,
                    TimeOfPayment = p.TimeOfPayment,
                    Total = p.Total,
                    Comment = p.Comment
                })
                .ToListAsync();
        }
       
    }
}