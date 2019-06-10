using Contracts.DAL.App.Repositories;
using Contracts.DAL.App.Repositories.Identity;
using ee.itcollege.sigrid.narep.Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IAppUserRepository AppUsers { get; }
        IAppRoleRepository AppRoles { get; }
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
        IUserSkillRepository UserSkills { get; }
       
    }
}
