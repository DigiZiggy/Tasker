using System;
using PublicApi.v1.Mappers.Identity;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class UserTaskMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.UserTask))
            {
                // map internal to external
                return MapFromBLL((internalDTO.UserTask) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.UserTask))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.UserTask) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.UserTask MapFromBLL(internalDTO.UserTask userTask)
        {
            var res = userTask == null ? null : new externalDTO.UserTask
            {
                Id = userTask.Id,
                Start = userTask.Start,
                End = userTask.End,
                TaskId = userTask.TaskId,
                TaskGiverId = userTask.TaskGiverId,
                TaskerId = userTask.TaskerId,
                TaskerTask = TaskerTaskMapper.MapFromBLL(userTask.TaskerTask),
                TaskGiver = AppUserMapper.MapFromBLL(userTask.TaskGiver),
                Tasker = AppUserMapper.MapFromBLL(userTask.Tasker)
            };

            return res;
        }

        public static internalDTO.UserTask MapFromExternal(externalDTO.UserTask userTask)
        {
            var res = userTask == null ? null : new internalDTO.UserTask
            {
                Id = userTask.Id,
                Start = userTask.Start,
                End = userTask.End,
                TaskId = userTask.TaskId,
                TaskGiverId = userTask.TaskGiverId,
                TaskerId = userTask.TaskerId,
                TaskerTask = TaskerTaskMapper.MapFromExternal(userTask.TaskerTask),
                TaskGiver = AppUserMapper.MapFromExternal(userTask.TaskGiver),
                Tasker = AppUserMapper.MapFromExternal(userTask.Tasker)
            };
            return res;
        }
    }
}