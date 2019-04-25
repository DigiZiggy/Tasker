using System;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBLL
    {
        IAddressService Addresses { get; }
        ICityService Cities { get; }
        ICountryService Countries { get; }
        IHourlyRateService HourlyRates { get; }
        IIdentificationService Identifications { get; }
        IIdentificationTypeService IdentificationTypes { get; }
        IInvoiceService Invoices { get; }
        IInvoiceLineService InvoiceLines { get; }
        IMeansOfPaymentService MeansOfPayments { get; }
        IPaymentService Payments { get; }
        IPriceListService PriceLists { get; }
        IPriceService Prices { get; }
        IReviewService Reviews { get; }
        ISkillService Skills { get; }
        ITaskService Tasks { get; }
        ITaskTypeService TaskTypes { get; }
        IUserGroupService UserGroups { get; }
        IUserInGroupService UserInGroups { get; }
        IUserOnAddressService UserOnAddresses { get; }
        IUserOnTaskService UserOnTasks { get; }
        IUserService Users { get; }
        IUserSkillService UserSills { get; }
        IUserTypeService UserTypes { get; }
        
        // DOTO: Public facing services
    }
}