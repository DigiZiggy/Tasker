using System;
using BLL.App.Mappers.Identity;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

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
                HourRate = hourlyRate.HourRate,
                Start = hourlyRate.Start,
                End = hourlyRate.End,
            };

            return res;
        }

        public static DAL.App.DTO.HourlyRate MapFromBLL(BLL.App.DTO.HourlyRate hourlyRate)
        {
            var res = hourlyRate == null ? null : new DAL.App.DTO.HourlyRate
            {
                Id = hourlyRate.Id,
                HourRate = hourlyRate.HourRate,
                Start = hourlyRate.Start,
                End = hourlyRate.End,
            };

            return res;
        }
    }
}