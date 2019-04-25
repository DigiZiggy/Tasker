using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class InvoiceLineRepository : BaseRepositoryAsync<InvoiceLine>, IInvoiceLineRepository
    {
        public InvoiceLineRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<InvoiceLine>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(i => i.Invoice)
                .Include(i => i.Task)
                .ToListAsync();  
        }
        
        public override async Task<InvoiceLine> FindAsync(params object[] id)
        {
            var invoiceLine = await base.FindAsync(id);

            if (invoiceLine != null)
            {
                await RepositoryDbContext.Entry(invoiceLine).Reference(i => i.Invoice).LoadAsync();
                await RepositoryDbContext.Entry(invoiceLine).Reference(i => i.Task).LoadAsync();
            }

            return invoiceLine;
        }
    }
}