using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        
        private readonly Dictionary<Type, object> _repositoryCache = new Dictionary<Type, object>();

        public IAddressRepository Addresses =>
            GetOrCreateRepository((AppDbContext dataContext) => new AddressRepository(dataContext));
        public ICityRepository Cities => 
            GetOrCreateRepository((AppDbContext dataContext) => new CityRepository(dataContext));

        public ICountryRepository Countries => 
            GetOrCreateRepository((AppDbContext dataContext) => new CountryRepository(dataContext));
        public IHourlyRateRepository HourlyRates => 
            GetOrCreateRepository((AppDbContext dataContext) => new HourlyRateRepository(dataContext));
        public IIdentificationRepository Identifications => 
            GetOrCreateRepository((AppDbContext dataContext) => new IdentificationRepository(dataContext));
        public IIdentificationTypeRepository IdentificationTypes => 
            GetOrCreateRepository((AppDbContext dataContext) => new IdentificationTypeRepository(dataContext));
        public IInvoiceRepository Invoices => 
            GetOrCreateRepository((AppDbContext dataContext) => new InvoiceRepository(dataContext));
        public IInvoiceLineRepository InvoiceLines => 
            GetOrCreateRepository((AppDbContext dataContext) => new InvoiceLineRepository(dataContext));
        public IMeansOfPaymentRepository MeansOfPayments => 
            GetOrCreateRepository((AppDbContext dataContext) => new MeansOfPaymentRepository(dataContext));
        public IPaymentRepository Payments => 
            GetOrCreateRepository((AppDbContext dataContext) => new PaymentRepository(dataContext));
        public IPriceListRepository PriceLists => 
            GetOrCreateRepository((AppDbContext dataContext) => new PriceListRepository(dataContext));
        public IPriceRepository Prices => 
            GetOrCreateRepository((AppDbContext dataContext) => new PriceRepository(dataContext));
        public IReviewRepository Reviews => 
            GetOrCreateRepository((AppDbContext dataContext) => new ReviewRepository(dataContext));
        public ISkillRepository Skills => 
            GetOrCreateRepository((AppDbContext dataContext) => new SkillRepository(dataContext));
        public ITaskRepository Tasks => 
            GetOrCreateRepository((AppDbContext dataContext) => new TaskRepository(dataContext));
        public ITaskTypeRepository TaskTypes => 
            GetOrCreateRepository((AppDbContext dataContext) => new TaskTypeRepository(dataContext));
        public IUserGroupRepository UserGroups => 
            GetOrCreateRepository((AppDbContext dataContext) => new UserGroupRepository(dataContext));
        public IUserInGroupRepository UserInGroups => 
            GetOrCreateRepository((AppDbContext dataContext) => new UserInGroupRepository(dataContext));
        public IUserOnAddressRepository UserOnAddresses => 
            GetOrCreateRepository((AppDbContext dataContext) => new UserOnAddressRepository(dataContext));
        public IUserOnTaskRepository UserOnTasks => 
            GetOrCreateRepository((AppDbContext dataContext) => new UserOnTaskRepository(dataContext));
        public IUserRepository Users => 
            GetOrCreateRepository((AppDbContext dataContext) => new UserRepository(dataContext));
        public IUserSkillRepository UserSills => 
            GetOrCreateRepository((AppDbContext dataContext) => new UserSkillRepository(dataContext));
        public IUserTypeRepository UserTypes => 
            GetOrCreateRepository((AppDbContext dataContext) => new UserTypeRepository(dataContext));

        
        public IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class, new()
        {
            return GetOrCreateRepository((AppDbContext dataContext) => new BaseRepository<TEntity>(dataContext));
        }
        

        private TRepository GetOrCreateRepository<TRepository>(Func<AppDbContext, TRepository> factoryMethod)
        {
            _repositoryCache.TryGetValue(typeof(TRepository), out var repoObject);
            if (repoObject != null)
            {
                return (TRepository) repoObject;
            }

            repoObject = factoryMethod(_appDbContext);
            _repositoryCache[typeof(TRepository)] = repoObject;
            return (TRepository) repoObject;
        }
        
        public AppUnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public virtual int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

    }
}