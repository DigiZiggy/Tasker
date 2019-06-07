using System;
using System.Collections.Generic;
using System.Linq;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class TaskerTaskMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.TaskerTask))
            {
                // map internal to external
                return MapFromBLL((internalDTO.TaskerTask) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.TaskerTask))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.TaskerTask) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.TaskerTask MapFromBLL(internalDTO.TaskerTask taskerTask)
        {
            var res = taskerTask == null ? null : new externalDTO.TaskerTask
            {
                Id = taskerTask.Id,
                TaskName = taskerTask.TaskName,
                Description = taskerTask.Description,
                TimeEstimate = taskerTask.TimeEstimate,
                AddressId = taskerTask.AddressId,
                Address = AddressMapper.MapFromBLL(taskerTask.Address),
                AppUsersInvolved = taskerTask.AppUsersInvolved.Select(e => UserTaskMapper.MapFromBLL(e)) as ICollection<externalDTO.UserTask>
            };

            return res;
        }

        public static internalDTO.TaskerTask MapFromExternal(externalDTO.TaskerTask taskerTask)
        {
            var res = taskerTask == null ? null : new internalDTO.TaskerTask
            {
                Id = taskerTask.Id,
                TaskName = taskerTask.TaskName,
                Description = taskerTask.Description,
                TimeEstimate = taskerTask.TimeEstimate,
                AddressId = taskerTask.AddressId,
                Address = AddressMapper.MapFromExternal(taskerTask.Address),
                AppUsersInvolved = taskerTask.AppUsersInvolved.Select(e => UserTaskMapper.MapFromExternal(e)) as ICollection<internalDTO.UserTask>
            };
            return res;
        }
    }
}