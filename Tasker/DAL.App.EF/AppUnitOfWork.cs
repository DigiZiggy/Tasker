using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Helpers;
using DAL.Base.EF;

namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork, IAppUnitOfWork
    {

        public AppUnitOfWork(IDataContext dbContext, IBaseRepositoryProvider repositoryProvider) : base(dbContext, repositoryProvider)
        {
        }
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
        public IUserSkillRepository UserSills => 
            _repositoryProvider.GetRepository<IUserSkillRepository>();
   
 
    }
}
