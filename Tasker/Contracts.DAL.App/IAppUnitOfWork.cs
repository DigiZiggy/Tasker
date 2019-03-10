using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        IAddressRepository Addresses { get; }
        ICityRepository Cities { get; }
        ICountryRepository Countries { get; }
        IHourlyRateRepository HourlyRates { get; }
        IIdentificationRepository Identifications { get; }
        IIdentificationTypeRepository IdentificationTypes { get; }
        IInvoiceRepository Invoices { get; }
        IInvoiceLineRepository InvoiceLines { get; }
        IMeansOfPaymentRepository MeansOfPayments { get; }
        IPaymentRepository Payments { get; }
        IPriceListRepository PriceLists { get; }
        IPriceRepository Prices { get; }
        IReviewRepository Reviews { get; }
        ISkillRepository Skills { get; }
        ITaskRepository Tasks { get; }
        ITaskTypeRepository TaskTypes { get; }
        IUserGroupRepository UserGroups { get; }
        IUserInGroupRepository UserInGroups { get; }
        IUserOnAddressRepository UserOnAddresses { get; }
        IUserOnTaskRepository UserOnTasks { get; }
        IUserRepository Users { get; }
        IUserSkillRepository UserSills { get; }
        IUserTypeRepository UserTypes { get; }
        
    }
}