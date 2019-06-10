using System;

namespace Contracts.Base
{
    public interface ITrackableInstance
    {
        Guid InstanceId { get; }  // initiate with =Guid.NewGuid()

    }
}
