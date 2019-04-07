using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Helpers;
using Contracts.DAL.Base.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork, IAppUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        private readonly IRepositoryProvider _repositoryProvider;

        public IAddressRepository Addresses =>
            _repositoryProvider.GetRepository<IAddressRepository>();
        public ICityRepository Cities => 
            _repositoryProvider.GetRepository<ICityRepository>();
        public ICountryRepository Countries => 
            _repositoryProvider.GetRepository<ICountryRepository>();
        public IHourlyRateRepository HourlyRates => 
            _repositoryProvider.GetRepository<IHourlyRateRepository>();
        public IIdentificationRepository Identifications => 
            _repositoryProvider.GetRepository<IIdentificationRepository>();
        public IIdentificationTypeRepository IdentificationTypes => 
            _repositoryProvider.GetRepository<IIdentificationTypeRepository>();
        public IInvoiceRepository Invoices => 
            _repositoryProvider.GetRepository<IInvoiceRepository>();
        public IInvoiceLineRepository InvoiceLines => 
            _repositoryProvider.GetRepository<IInvoiceLineRepository>();
        public IMeansOfPaymentRepository MeansOfPayments => 
            _repositoryProvider.GetRepository<IMeansOfPaymentRepository>();
        public IPaymentRepository Payments => 
            _repositoryProvider.GetRepository<IPaymentRepository>();
        public IPriceListRepository PriceLists => 
            _repositoryProvider.GetRepository<IPriceListRepository>();
        public IPriceRepository Prices => 
            _repositoryProvider.GetRepository<IPriceRepository>();
        public IReviewRepository Reviews => 
            _repositoryProvider.GetRepository<IReviewRepository>();
        public ISkillRepository Skills => 
            _repositoryProvider.GetRepository<ISkillRepository>();
        public ITaskRepository Tasks => 
            _repositoryProvider.GetRepository<ITaskRepository>();
        public ITaskTypeRepository TaskTypes => 
            _repositoryProvider.GetRepository<ITaskTypeRepository>();
        public IUserGroupRepository UserGroups => 
            _repositoryProvider.GetRepository<IUserGroupRepository>();
        public IUserInGroupRepository UserInGroups => 
            _repositoryProvider.GetRepository<IUserInGroupRepository>();
        public IUserOnAddressRepository UserOnAddresses => 
            _repositoryProvider.GetRepository<IUserOnAddressRepository>();
        public IUserOnTaskRepository UserOnTasks => 
            _repositoryProvider.GetRepository<IUserOnTaskRepository>();
        public IUserRepository Users => 
            _repositoryProvider.GetRepository<IUserRepository>();
        public IUserSkillRepository UserSills => 
            _repositoryProvider.GetRepository<IUserSkillRepository>();
        public IUserTypeRepository UserTypes => 
            _repositoryProvider.GetRepository<IUserTypeRepository>();

        
        public IBaseRepositoryAsync<TEntity> BaseRepository<TEntity>() where TEntity : class, IBaseEntity, new()
        {
            return _repositoryProvider.GetRepositoryForEntity<TEntity>();
        }
        
        
        public AppUnitOfWork(AppDbContext dbContext, IDataContext dataContext, IRepositoryProvider repositoryProvider) : base(dbContext)
        {
            _appDbContext = (dataContext as AppDbContext) ?? throw new ArgumentNullException(nameof(dataContext));
            _repositoryProvider = repositoryProvider;
        }

        public virtual int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }

        public new virtual async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

    }
}