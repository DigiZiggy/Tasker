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
            ServiceRepository = Uow.Invoices;
        }

        public override async Task<BLL.App.DTO.Invoice> FindAsync(params object[] id)
        {
            return InvoiceMapper.MapFromDAL(await Uow.Invoices.FindAsync(id));
        }
      
    }
}