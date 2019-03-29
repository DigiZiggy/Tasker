using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Invoice>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(i => i.User)
                .ToListAsync();          
        }
        
        public override async Task<Invoice> FindAsync(params object[] id)
        {
            var invoice = await base.FindAsync(id);

            if (invoice != null)
            {
                await RepositoryDbContext.Entry(invoice).Reference(i => i.User).LoadAsync();
            }

            return invoice;
        }
    }
}