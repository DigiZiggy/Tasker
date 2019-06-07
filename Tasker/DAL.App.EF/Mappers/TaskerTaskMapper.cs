using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class TaskerTaskMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.TaskerTask))
            {
                return MapFromDomain((Domain.TaskerTask) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.TaskerTask))
            {
                return MapFromDAL((DAL.App.DTO.TaskerTask) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DAL.App.DTO.TaskerTask MapFromDomain(Domain.TaskerTask taskerTask)
        {
            var res = taskerTask == null ? null : new DAL.App.DTO.TaskerTask
            {
                Id = taskerTask.Id,
                TaskName = taskerTask.TaskName,
                Description = taskerTask.Description,
                TimeEstimate = taskerTask.TimeEstimate,
                AddressId = taskerTask.AddressId,
                Address = AddressMapper.MapFromDomain(taskerTask.Address),
                AppUsersInvolved = taskerTask.AppUsersInvolved.Select(e => UserTaskMapper.MapFromDomain(e)) as ICollection<UserTask>
            };


            return res;
        }

        public static Domain.TaskerTask MapFromDAL(DAL.App.DTO.TaskerTask taskerTask)
        {
            var res = taskerTask == null ? null : new Domain.TaskerTask
            {
                Id = taskerTask.Id,
                TaskName = taskerTask.TaskName,
                Description = taskerTask.Description,
                TimeEstimate = taskerTask.TimeEstimate,
                AddressId = taskerTask.AddressId,
                Address = AddressMapper.MapFromDAL(taskerTask.Address),
                AppUsersInvolved = taskerTask.AppUsersInvolved.Select(e => UserTaskMapper.MapFromDAL(e)) as ICollection<Domain.UserTask>
            };


            return res;
        }
    }
}