using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        IAddressRepository Addresses { get; }
        IHourlyRateRepository HourlyRates { get; }
        IIdentificationRepository Identifications { get; }
        IInvoiceRepository Invoices { get; }
        IPaymentRepository Payments { get; }
        IReviewRepository Reviews { get; }
        ISkillRepository Skills { get; }
        ITaskerTaskRepository Tasks { get; }
        IUserOnAddressRepository UserOnAddresses { get; }
        IUserTaskRepository UserTasks { get; }
        IUserSkillRepository UserSills { get; }
        
    }
}
