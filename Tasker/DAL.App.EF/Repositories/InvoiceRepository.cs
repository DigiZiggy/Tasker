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
    public class InvoiceRepository : BaseRepository<DAL.App.DTO.Invoice, Domain.Invoice, AppDbContext>, IInvoiceRepository
    {
        public InvoiceRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new InvoiceMapper())
        {
        }
        
        public override async Task<List<DAL.App.DTO.Invoice>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(i => i.AppUser)
                .Select(e => InvoiceMapper.MapFromDomain(e)).ToListAsync();         
        }
        
        public async Task<List<DAL.App.DTO.Invoice>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(i => i.AppUser)
                .Where(c => c.AppUser.Id == userId)
                .Select(e => InvoiceMapper.MapFromDomain(e)).ToListAsync();

        }
        
        public async Task<DAL.App.DTO.Invoice> FindAllIncludedAsync(params object[] id)
        {
            var invoice = await base.FindAsync(id);

            if (invoice != null)
            {
                await RepositoryDbContext.Entry(invoice).Reference(i => i.AppUser).LoadAsync();
            }
            return invoice;
        }

        public Task<Invoice> FindForUserAsync(int id, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}