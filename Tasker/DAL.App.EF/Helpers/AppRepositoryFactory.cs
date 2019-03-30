using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF.Helpers;

namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory : BaseRepositoryFactory
    {
        public AppRepositoryFactory()
        {
            // add to dict all the repo creation methods we might need
            
            RepositoryCreationMethods.Add(typeof(IAddressRepository), 
                dataContext => new AddressRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ICityRepository), 
                dataContext => new CityRepository(dataContext));

            RepositoryCreationMethods.Add(typeof(ICountryRepository), 
                dataContext => new CountryRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IHourlyRateRepository), 
                dataContext => new HourlyRateRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IIdentificationRepository), 
                dataContext => new IdentificationRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IIdentificationTypeRepository), 
                dataContext => new IdentificationTypeRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IInvoiceLineRepository), 
                dataContext => new InvoiceLineRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IInvoiceRepository), 
                dataContext => new InvoiceRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IMeansOfPaymentRepository), 
                dataContext => new MeansOfPaymentRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IPaymentRepository), 
                dataContext => new PaymentRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IPriceListRepository), 
                dataContext => new PriceListRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IPriceRepository), 
                dataContext => new PriceRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IReviewRepository), 
                dataContext => new ReviewRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ISkillRepository), 
                dataContext => new SkillRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ITaskRepository), 
                dataContext => new TaskRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ITaskTypeRepository), 
                dataContext => new TaskTypeRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IUserGroupRepository), 
                dataContext => new UserGroupRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IUserInGroupRepository), 
                dataContext => new UserInGroupRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IUserOnAddressRepository), 
                dataContext => new UserOnAddressRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IUserOnTaskRepository), 
                dataContext => new UserOnTaskRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IUserRepository), 
                dataContext => new UserRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IUserSkillRepository), 
                dataContext => new UserSkillRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IUserTypeRepository), 
                dataContext => new UserTypeRepository(dataContext));
          
        }
    }
}