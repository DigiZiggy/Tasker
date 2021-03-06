using System;
using BLL.App.Mappers.Identity;
using ee.itcollege.sigrid.narep.Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class TaskerTaskMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.TaskerTask))
            {
                return MapFromDAL((DAL.App.DTO.TaskerTask) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.TaskerTask))
            {
                return MapFromBLL((BLL.App.DTO.TaskerTask) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.TaskerTask MapFromDAL(DAL.App.DTO.TaskerTask taskerTask)
        {
            var res = taskerTask == null ? null : new BLL.App.DTO.TaskerTask
            {
                Id = taskerTask.Id,
                TaskName = taskerTask.TaskName,
                Description = taskerTask.Description,
                TimeEstimate = taskerTask.TimeEstimate,
                AddressId = taskerTask.AddressId,
                Address = AddressMapper.MapFromDAL(taskerTask.Address),
            };

            return res;
        }

        public static DAL.App.DTO.TaskerTask MapFromBLL(BLL.App.DTO.TaskerTask taskerTask)
        {
            var res = taskerTask == null ? null : new DAL.App.DTO.TaskerTask
            {
                Id = taskerTask.Id,
                TaskName = taskerTask.TaskName,
                Description = taskerTask.Description,
                TimeEstimate = taskerTask.TimeEstimate,
                AddressId = taskerTask.AddressId,
                Address = AddressMapper.MapFromBLL(taskerTask.Address),
            };

            return res;
        }
    }
}