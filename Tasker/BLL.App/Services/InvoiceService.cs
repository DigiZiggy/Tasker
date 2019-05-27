using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class InvoiceService : BaseEntityService<Invoice, IAppUnitOfWork>, IInvoiceService
    {
        public InvoiceService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<Invoice> FindAllIncludedAsync(params object[] id)
        {
            return await Uow.Invoices.FindAllIncludedAsync(id);

        }
    }
}