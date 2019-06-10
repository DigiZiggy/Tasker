using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using ee.itcollege.sigrid.narep.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Payment = DAL.App.DTO.Payment;

namespace DAL.App.EF.Repositories
{
    public class PaymentRepository : BaseRepository<DAL.App.DTO.Payment, Domain.Payment, AppDbContext>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new PaymentMapper())
        {
        }
        
//        public override async Task<Payment> FindAsync(params object[] id)
//        {
//            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
//            
//            var payment = await RepositoryDbSet.FindAsync(id);
//            if (payment != null)
//            {
//                await RepositoryDbContext.Entry(payment)
//                    .Reference(c => c.MeansOfPayment)
//                    .LoadAsync();
//                await RepositoryDbContext.Entry(payment)
//                    .Reference(c => c.Comment)
//                    .LoadAsync();
//                
//                await RepositoryDbContext.Entry(payment.MeansOfPayment)
//                    .Collection(b => b.Translations)
//                    .Query()
//                    .Where(t => t.Culture == culture)
//                    .LoadAsync();
//                await RepositoryDbContext.Entry(payment.Comment)
//                    .Collection(b => b.Translations)
//                    .Query()
//                    .Where(t => t.Culture == culture)
//                    .LoadAsync();
//            }
// 
//            return PaymentMapper.MapFromDomain(payment);
//        }
//
//        public override Payment Update(Payment entity)
//        {
//            var entityInDb = RepositoryDbSet
//                .Include(m => m.MeansOfPayment)
//                .Include(m => m.Comment)
//                .ThenInclude(t => t.Translations)
//                .FirstOrDefault(x => x.Id == entity.Id);
//
//            entityInDb.MeansOfPayment.SetTranslation(entity.MeansOfPayment);
//            entityInDb.Comment.SetTranslation(entity.Comment);
//
//            return entity;
//        }
//        
//        public override async Task<List<DAL.App.DTO.Payment>> AllAsync()
//        {
//            return await RepositoryDbSet
//                .Include(m => m.MeansOfPayment)
//                .ThenInclude(t => t.Translations)
//                .Include(m => m.Comment)
//                .ThenInclude(t => t.Translations)
//                .Include(p => p.Invoice)
//                .Select(p => PaymentMapper.MapFromDomain(p)).ToListAsync();          
//        }
    }
}