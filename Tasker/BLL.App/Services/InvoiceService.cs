using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;


namespace BLL.App.Services
{
    public class InvoiceService : BaseEntityService<BLL.App.DTO.Invoice, DAL.App.DTO.Invoice, IAppUnitOfWork>, IInvoiceService
    {
        public InvoiceService(IAppUnitOfWork uow) : base(uow, new InvoiceMapper())
        {
            ServiceRepository = Uow.BaseRepository<DAL.App.DTO.Invoice, Domain.Invoice>();
        }

        public async Task<BLL.App.DTO.Invoice> FindAllIncludedAsync(params object[] id)
        {
            return InvoiceMapper.MapFromDAL(await Uow.Invoices.FindAllIncludedAsync(id));
        }
        
        public async Task<BLL.App.DTO.Invoice> FindForUserAsync(int id, int userId)
        {
            return InvoiceMapper.MapFromDAL(await Uow.Invoices.FindForUserAsync(id, userId));
        }
        
        public async Task<List<BLL.App.DTO.Invoice>> AllForUserAsync(int userId)
        {
            return (await Uow.Invoices.AllForUserAsync(userId)).Select(e => InvoiceMapper.MapFromDAL(e)).ToList();
        }
    }
}