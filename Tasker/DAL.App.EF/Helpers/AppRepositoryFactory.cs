using Contracts.DAL.App.Repositories;
using Contracts.DAL.App.Repositories.Identity;
using Contracts.DAL.Base.Helpers;
using DAL.App.EF.Repositories;
using DAL.App.EF.Repositories.Identity;
using DAL.Base.EF.Helpers;
using AppUserRepository = DAL.App.EF.Repositories.AppUserRepository;

namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory : BaseRepositoryFactory<AppDbContext>
    {
        public AppRepositoryFactory()
        {
            RegisterRepositories();
        }

        private void RegisterRepositories()
        {
            AddToCreationMethods<IAppUserRepository>(dataContext => new AppUserRepository(dataContext));
            AddToCreationMethods<IAppRoleRepository>(dataContext => new AppRoleRepository(dataContext));
            AddToCreationMethods<IAddressRepository>(dataContext => new AddressRepository(dataContext));
            AddToCreationMethods<IHourlyRateRepository>(dataContext => new HourlyRateRepository(dataContext));
            AddToCreationMethods<IIdentificationRepository>(dataContext => new IdentificationRepository(dataContext));
            AddToCreationMethods<IInvoiceRepository>(dataContext => new InvoiceRepository(dataContext));
            AddToCreationMethods<IPaymentRepository>(dataContext => new PaymentRepository(dataContext));
            AddToCreationMethods<IReviewRepository>(dataContext => new ReviewRepository(dataContext));
            AddToCreationMethods<ISkillRepository>(dataContext => new SkillRepository(dataContext));
            AddToCreationMethods<ITaskerTaskRepository>(dataContext => new TaskerTaskRepository(dataContext));
            AddToCreationMethods<IUserOnAddressRepository>(dataContext => new UserOnAddressRepository(dataContext));
            AddToCreationMethods<IUserTaskRepository>(dataContext => new UserTaskRepository(dataContext));
            AddToCreationMethods<IUserSkillRepository>(dataContext => new UserSkillRepository(dataContext));
        }
    }
}
