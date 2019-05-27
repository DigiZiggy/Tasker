using BLL.App.Services;
using BLL.Base.Helpers;
using Contracts.BLL.App.Services;
using Contracts.BLL.App.Services.Identity;
using Contracts.DAL.App;

namespace BLL.App.Helpers
{
    public class AppServiceFactory : BaseServiceFactory<IAppUnitOfWork>
    {
        public AppServiceFactory()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            // Registering all my custom services here!
            AddToCreationMethods<IAppUserService>(uow => new AppUserService(uow));
            AddToCreationMethods<IAppRoleService>(uow => new AppRoleService(uow));
            AddToCreationMethods<IAddressService>(uow => new AddressService(uow));
            AddToCreationMethods<IHourlyRateService>(uow => new HourlyRateService(uow));
            AddToCreationMethods<IIdentificationService>(uow => new IdentificationService(uow));
            AddToCreationMethods<IInvoiceService>(uow => new InvoiceService(uow));
            AddToCreationMethods<IPaymentService>(uow => new PaymentService(uow));
            AddToCreationMethods<IReviewService>(uow => new ReviewService(uow));
            AddToCreationMethods<ISkillService>(uow => new SkillService(uow));
            AddToCreationMethods<ITaskerTaskService>(uow => new TaskerTaskService(uow));
            AddToCreationMethods<IUserOnAddressService>(uow => new UserOnAddressService(uow));
            AddToCreationMethods<IUserSkillService>(uow => new UserSkillService(uow));
            AddToCreationMethods<IUserTaskService>(uow => new UserTaskService(uow));
        }
    }
}