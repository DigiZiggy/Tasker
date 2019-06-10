using System;
using DAL.App.DTO;
using DAL.App.EF.Mappers.Identity;
using ee.itcollege.sigrid.narep.Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class UserTaskMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.UserTask))
            {
                return MapFromDomain((Domain.UserTask) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.UserTask))
            {
                return MapFromDAL((DAL.App.DTO.UserTask) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DAL.App.DTO.UserTask MapFromDomain(Domain.UserTask userTask)
        {
            var res = userTask == null ? null : new DAL.App.DTO.UserTask
            {
                Id = userTask.Id,
                Start = userTask.Start,
                End = userTask.End,
                TaskId = userTask.TaskId,
                TaskGiverId = userTask.TaskGiverId,
                TaskerId = userTask.TaskerId,
                TaskerTask = TaskerTaskMapper.MapFromDomain(userTask.TaskerTask),
                TaskGiver = AppUserMapper.MapFromDomain(userTask.TaskGiver),
                Tasker = AppUserMapper.MapFromDomain(userTask.Tasker)
            };


            return res;
        }

        public static Domain.UserTask MapFromDAL(DAL.App.DTO.UserTask userTask)
        {
            var res = userTask == null ? null : new Domain.UserTask
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
    }
}