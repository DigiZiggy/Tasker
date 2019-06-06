using System;
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

        public static DAL.App.DTO.TaskerTask MapFromDomain(Domain.TaskerTask task)
        {
            var res = task == null ? null : new DAL.App.DTO.TaskerTask
            {
                Id = task.Id,

            };


            return res;
        }

        public static Domain.TaskerTask MapFromDAL(DAL.App.DTO.TaskerTask task)
        {
            var res = task == null ? null : new Domain.TaskerTask
            {
                Id = task.Id,

            };


            return res;
        }
    }
}