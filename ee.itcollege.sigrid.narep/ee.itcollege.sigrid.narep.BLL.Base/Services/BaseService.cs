using System;
using ee.itcollege.sigrid.narep.Contracts.BLL.Base.Services;

namespace ee.itcollege.sigrid.narep.BLL.Base.Services
{
    public class BaseService : IBaseService
    {
        private readonly Guid _instanceId = Guid.NewGuid();
        public Guid InstanceId => _instanceId;
    }

}
