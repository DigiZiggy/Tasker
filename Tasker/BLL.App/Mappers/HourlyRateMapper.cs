using System;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class HourlyRateMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.HourlyRate))
            {
                return MapFromDAL((DAL.App.DTO.HourlyRate) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.HourlyRate))
            {
                return MapFromBLL((BLL.App.DTO.HourlyRate) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.HourlyRate MapFromDAL(DAL.App.DTO.HourlyRate hourlyRate)
        {
            var res = hourlyRate == null ? null : new BLL.App.DTO.HourlyRate
            {
                Id = hourlyRate.Id,

            };

            return res;
        }

        public static DAL.App.DTO.HourlyRate MapFromBLL(BLL.App.DTO.HourlyRate hourlyRate)
        {
            var res = hourlyRate == null ? null : new DAL.App.DTO.HourlyRate
            {
                Id = hourlyRate.Id,
            };

            return res;
        }
    }
}