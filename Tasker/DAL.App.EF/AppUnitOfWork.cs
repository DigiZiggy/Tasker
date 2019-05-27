using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.App.Repositories.Identity;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Helpers;
using DAL.Base.EF;

namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        
        public AppUnitOfWork(AppDbContext dbContext, IBaseRepositoryProvider repositoryProvider) : base(dbContext, repositoryProvider)
        {
        }     
        
        public IAppUserRepository AppUsers =>
            _repositoryProvider.GetRepository<IAppUserRepository>();
        public IAppRoleRepository AppRoles =>
            _repositoryProvider.GetRepository<IAppRoleRepository>();
        public IAddressRepository Addresses =>
            _repositoryProvider.GetRepository<IAddressRepository>();
        public IHourlyRateRepository HourlyRates => 
            _repositoryProvider.GetRepository<IHourlyRateRepository>();
        public IIdentificationRepository Identifications => 
            _repositoryProvider.GetRepository<IIdentificationRepository>();
        public IInvoiceRepository Invoices => 
            _repositoryProvider.GetRepository<IInvoiceRepository>();
        public IPaymentRepository Payments => 
            _repositoryProvider.GetRepository<IPaymentRepository>();
        public IReviewRepository Reviews => 
            _repositoryProvider.GetRepository<IReviewRepository>();
        public ISkillRepository Skills => 
            _repositoryProvider.GetRepository<ISkillRepository>();
        public ITaskerTaskRepository Tasks => 
            _repositoryProvider.GetRepository<ITaskerTaskRepository>();
        public IUserOnAddressRepository UserOnAddresses => 
            _repositoryProvider.GetRepository<IUserOnAddressRepository>();
        public IUserTaskRepository UserTasks => 
            _repositoryProvider.GetRepository<IUserTaskRepository>();
        public IUserSkillRepository UserSkills => 
            _repositoryProvider.GetRepository<IUserSkillRepository>();
   
    }
}
