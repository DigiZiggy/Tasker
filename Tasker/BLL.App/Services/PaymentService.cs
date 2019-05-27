using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class PaymentService : BaseEntityService<Payment, IAppUnitOfWork>, IPaymentService
    {
        public PaymentService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<Payment> FindAllIncludedAsync(params object[] id)
        {
            return await Uow.Payments.FindAllIncludedAsync(id);

        }
    }
}