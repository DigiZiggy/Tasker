using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class InvoiceRepository : BaseRepository<Invoice, AppDbContext>, IInvoiceRepository
    {
        public InvoiceRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        
        public override async Task<List<Invoice>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(i => i.AppUser)
                .ToListAsync();          
        }
        
        public async Task<Invoice> FindAllIncludedAsync(params object[] id)
        {
            var invoice = await base.FindAsync(id);

            if (invoice != null)
            {
                await RepositoryDbContext.Entry(invoice).Reference(i => i.AppUser).LoadAsync();
            }
            return invoice;
        }
    }
}