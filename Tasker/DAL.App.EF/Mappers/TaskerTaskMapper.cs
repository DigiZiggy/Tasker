using System;
using System.Collections.Generic;
using System.Linq;
using DAL.App.DTO;
using ee.itcollege.sigrid.narep.Contracts.DAL.Base.Mappers;

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
                TaskName = taskerTask.TaskName.Translate(),
                Description = taskerTask.Description.Translate(),
                TimeEstimate = taskerTask.TimeEstimate,
                AddressId = taskerTask.AddressId,
                Address = AddressMapper.MapFromDomain(taskerTask.Address),
            };


            return res;
        }

        public static Domain.TaskerTask MapFromDAL(DAL.App.DTO.TaskerTask taskerTask)
        {
            var res = taskerTask == null ? null : new Domain.TaskerTask
            {
                Id = taskerTask.Id,
                TaskName = new Domain.MultiLangString(taskerTask.TaskName),
                Description = new Domain.MultiLangString(taskerTask.Description),
                TimeEstimate = taskerTask.TimeEstimate,
                AddressId = taskerTask.AddressId,
                Address = AddressMapper.MapFromDAL(taskerTask.Address),
            };


            return res;
        }
    }
}