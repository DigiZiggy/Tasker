using System;
using BLL.App.Mappers.Identity;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class UserTaskMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.UserTask))
            {
                return MapFromDAL((internalDTO.UserTask) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.UserTask))
            {
                return MapFromBLL((externalDTO.UserTask) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.UserTask MapFromDAL(internalDTO.UserTask userTask)
        {
            var res = userTask == null ? null : new externalDTO.UserTask
            {
                Id = userTask.Id,
                Start = userTask.Start,
                End = userTask.End,
                TaskId = userTask.TaskId,
                TaskGiverId = userTask.TaskGiverId,
                TaskerId = userTask.TaskerId,
                TaskerTask = TaskerTaskMapper.MapFromDAL(userTask.TaskerTask),
                TaskGiver = AppUserMapper.MapFromDAL(userTask.TaskGiver),
                Tasker = AppUserMapper.MapFromDAL(userTask.Tasker)
            };

            return res;
        }

        public static internalDTO.UserTask MapFromBLL(externalDTO.UserTask userTask)
        {
            var res = userTask == null ? null : new internalDTO.UserTask
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
    }
}