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
        
        public IAddressRepository Addresses => new AddressRepository(_appDbContext);
        public ICityRepository Cities => new CityRepository(_appDbContext);
        public ICountryRepository Countries => new CountryRepository(_appDbContext);
        public IHourlyRateRepository HourlyRates => new HourlyRateRepository(_appDbContext);
        public IIdentificationRepository Identifications => new IdentificationRepository(_appDbContext);
        public IIdentificationTypeRepository IdentificationTypes => new IdentificationTypeRepository(_appDbContext);
        public IInvoiceRepository Invoices => new InvoiceRepository(_appDbContext);
        public IInvoiceLineRepository InvoiceLines => new InvoiceLineRepository(_appDbContext);
        public IMeansOfPaymentRepository MeansOfPayments => new MeansOfPaymentRepository(_appDbContext);
        public IPaymentRepository Payments => new PaymentRepository(_appDbContext);
        public IPriceListRepository PriceLists => new PriceListRepository(_appDbContext);
        public IPriceRepository Prices => new PriceRepository(_appDbContext);
        public IReviewRepository Reviews => new ReviewRepository(_appDbContext);
        public ISkillRepository Skills => new SkillRepository(_appDbContext);
        public ITaskRepository Tasks => new TaskRepository(_appDbContext);
        public ITaskTypeRepository TaskTypes => new TaskTypeRepository(_appDbContext);
        public IUserGroupRepository UserGroups => new UserGroupRepository(_appDbContext);
        public IUserInGroupRepository UserInGroups => new UserInGroupRepository(_appDbContext);
        public IUserOnAddressRepository UserOnAddresses => new UserOnAddressRepository(_appDbContext);
        public IUserOnTaskRepository UserOnTasks => new UserOnTaskRepository(_appDbContext);
        public IUserRepository Users => new UserRepository(_appDbContext);
        public IUserSkillRepository UserSills => new UserSkillRepository(_appDbContext);
        public IUserTypeRepository UserTypes => new UserTypeRepository(_appDbContext);
        

        public AppUnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class, new()
        {
            return new BaseRepository<TEntity>(_appDbContext);
        }

    }
}