using System;
using BLL.Base;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.BLL.App.Services.Identity;
using Contracts.BLL.Base.Helpers;
using Contracts.DAL.App;

namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        protected readonly IAppUnitOfWork AppUnitOfWork;
        
        public AppBLL(IAppUnitOfWork appUnitOfWork, IBaseServiceProvider serviceProvider) : base(appUnitOfWork, serviceProvider)
        {
            AppUnitOfWork = appUnitOfWork;
        }

        public IAppUserService AppUsers => ServiceProvider.GetService<IAppUserService>();        
        public IAppRoleService AppRoles => ServiceProvider.GetService<IAppRoleService>();
        public IAddressService Addresses => ServiceProvider.GetService<IAddressService>();
        public IHourlyRateService HourlyRates => ServiceProvider.GetService<IHourlyRateService>();
        public IIdentificationService Identifications => ServiceProvider.GetService<IIdentificationService>();       
        public IInvoiceService Invoices => ServiceProvider.GetService<IInvoiceService>();
        public IPaymentService Payments => ServiceProvider.GetService<IPaymentService>();
        public IReviewService Reviews => ServiceProvider.GetService<IReviewService>();        
        public ISkillService Skills => ServiceProvider.GetService<ISkillService>();
        public ITaskerTaskService Tasks => ServiceProvider.GetService<ITaskerTaskService>();
        public IUserOnAddressService UserOnAddresses => ServiceProvider.GetService<IUserOnAddressService>();       
        public IUserTaskService UserTasks => ServiceProvider.GetService<IUserTaskService>();
        public IUserSkillService UserSkills => ServiceProvider.GetService<IUserSkillService>();      
    }
}