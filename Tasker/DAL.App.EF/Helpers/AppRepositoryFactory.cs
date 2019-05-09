using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Helpers;
using DAL.App.EF.Repositories;
using DAL.Base.EF.Helpers;

namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory : BaseRepositoryFactory, IBaseRepositoryFactory
    {
        public AppRepositoryFactory()
        {
            // add to dict all the repo creation methods we might need            
            _repositoryCreationMethodCache.Add(typeof(IAppUserRepository), 
                dataContext => new AppUserRepository(dataContext));
            
            _repositoryCreationMethodCache.Add(typeof(IAddressRepository), 
                dataContext => new AddressRepository(dataContext));
            
            _repositoryCreationMethodCache.Add(typeof(IHourlyRateRepository), 
                dataContext => new HourlyRateRepository(dataContext));
            
            _repositoryCreationMethodCache.Add(typeof(IIdentificationRepository), 
                dataContext => new IdentificationRepository(dataContext));
            
            _repositoryCreationMethodCache.Add(typeof(IInvoiceRepository), 
                dataContext => new InvoiceRepository(dataContext));

            _repositoryCreationMethodCache.Add(typeof(IPaymentRepository), 
                dataContext => new PaymentRepository(dataContext));
           
            _repositoryCreationMethodCache.Add(typeof(IReviewRepository), 
                dataContext => new ReviewRepository(dataContext));
            
            _repositoryCreationMethodCache.Add(typeof(ISkillRepository), 
                dataContext => new SkillRepository(dataContext));
            
            _repositoryCreationMethodCache.Add(typeof(ITaskerTaskRepository), 
                dataContext => new TaskerTaskRepository(dataContext));
            
            _repositoryCreationMethodCache.Add(typeof(IUserOnAddressRepository), 
                dataContext => new UserOnAddressRepository(dataContext));
            
            _repositoryCreationMethodCache.Add(typeof(IUserTaskRepository), 
                dataContext => new UserTaskRepository(dataContext));
            
            _repositoryCreationMethodCache.Add(typeof(IUserSkillRepository), 
                dataContext => new UserSkillRepository(dataContext));
            
        }
    }
}
