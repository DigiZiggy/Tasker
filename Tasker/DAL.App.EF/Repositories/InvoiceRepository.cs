using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Invoice = DAL.App.DTO.Invoice;

namespace DAL.App.EF.Repositories
{
    public class InvoiceRepository : BaseRepository<DAL.App.DTO.Invoice, Domain.Invoice, AppDbContext>, IInvoiceRepository
    {
        public InvoiceRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new InvoiceMapper())
        {
        }
        
//        public override async Task<Invoice> FindAsync(params object[] id)
//        {
//            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
//            
//            var invoice = await RepositoryDbSet.FindAsync(id);
//            if (invoice != null)
//            {
//                await RepositoryDbContext.Entry(invoice)
//                    .Reference(c => c.Comment)
//                    .LoadAsync();
//                
//                await RepositoryDbContext.Entry(invoice.Comment)
//                    .Collection(b => b.Translations)
//                    .Query()
//                    .Where(t => t.Culture == culture)
//                    .LoadAsync();
//            }
// 
//            return InvoiceMapper.MapFromDomain(invoice);
//        }
//
//        public override Invoice Update(Invoice entity)
//        {
//            var entityInDb = RepositoryDbSet
//                .Include(m => m.Comment)
//                .ThenInclude(t => t.Translations)
//                .FirstOrDefault(x => x.Id == entity.Id);
//
//            entityInDb.Comment.SetTranslation(entity.Comment);
//
//            return entity;
//        }
//        
//        public override async Task<List<DAL.App.DTO.Invoice>> AllAsync()
//        {
//            return await RepositoryDbSet
//                .Include(m => m.Comment)
//                .ThenInclude(t => t.Translations)
//                .Include(i => i.AppUser)
//                .Select(e => InvoiceMapper.MapFromDomain(e)).ToListAsync();         
//        }
    }
}