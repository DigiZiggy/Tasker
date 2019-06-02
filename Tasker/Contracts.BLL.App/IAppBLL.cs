using System;
using Contracts.BLL.App.Services;
using Contracts.BLL.App.Services.Identity;
using Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        IAppUserService AppUsers { get; }
        IAppRoleService AppRoles { get; }
        IAddressService Addresses { get; }
        IHourlyRateService HourlyRates { get; }
        IIdentificationService Identifications { get; }
        IInvoiceService Invoices { get; }
        IPaymentService Payments { get; }
        IReviewService Reviews { get; }
        ISkillService Skills { get; }
        ITaskerTaskService Tasks { get; }
        IUserOnAddressService UserOnAddresses { get; }
        IUserTaskService UserTasks { get; }
        IUserSkillService UserSkills { get; }
        // TODO: Public facing services
    }
}