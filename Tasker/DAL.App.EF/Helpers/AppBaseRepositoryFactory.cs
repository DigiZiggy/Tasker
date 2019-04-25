using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Helpers;
using DAL.App.EF.Repositories;
using DAL.Base.EF.Helpers;

namespace DAL.App.EF.Helpers
{
    public class AppBaseRepositoryFactory : BaseRepositoryFactory, IBaseRepositoryFactory
    {
        public AppBaseRepositoryFactory()
        {
            // add to dict all the repo creation methods we might need
            
            _repositoryCreationMethods.Add(typeof(IAddressRepository), 
                dataContext => new AddressRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(ICityRepository), 
                dataContext => new CityRepository(dataContext));

            _repositoryCreationMethods.Add(typeof(ICountryRepository), 
                dataContext => new CountryRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IHourlyRateRepository), 
                dataContext => new HourlyRateRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IIdentificationRepository), 
                dataContext => new IdentificationRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IIdentificationTypeRepository), 
                dataContext => new IdentificationTypeRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IInvoiceLineRepository), 
                dataContext => new InvoiceLineRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IInvoiceRepository), 
                dataContext => new InvoiceRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IMeansOfPaymentRepository), 
                dataContext => new MeansOfPaymentRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IPaymentRepository), 
                dataContext => new PaymentRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IPriceListRepository), 
                dataContext => new PriceListRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IPriceRepository), 
                dataContext => new PriceRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IReviewRepository), 
                dataContext => new ReviewRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(ISkillRepository), 
                dataContext => new SkillRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(ITaskRepository), 
                dataContext => new TaskRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(ITaskTypeRepository), 
                dataContext => new TaskTypeRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IUserGroupRepository), 
                dataContext => new UserGroupRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IUserInGroupRepository), 
                dataContext => new UserInGroupRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IUserOnAddressRepository), 
                dataContext => new UserOnAddressRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IUserOnTaskRepository), 
                dataContext => new UserOnTaskRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IUserRepository), 
                dataContext => new UserRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IUserSkillRepository), 
                dataContext => new UserSkillRepository(dataContext));
            
            _repositoryCreationMethods.Add(typeof(IUserTypeRepository), 
                dataContext => new UserTypeRepository(dataContext));
          
        }
    }
}