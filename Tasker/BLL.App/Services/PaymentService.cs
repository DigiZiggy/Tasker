using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.sigrid.narep.BLL.Base.Services;


namespace BLL.App.Services
{
    public class PaymentService : BaseEntityService<BLL.App.DTO.Payment, DAL.App.DTO.Payment, IAppUnitOfWork>, IPaymentService
    {
        public PaymentService(IAppUnitOfWork uow) : base(uow, new PaymentMapper())
        {
            ServiceRepository = Uow.Payments;
        }

        public override async Task<BLL.App.DTO.Payment> FindAsync(params object[] id)
        {
            return PaymentMapper.MapFromDAL(await Uow.Payments.FindAsync(id));
        }

    }
}