using System;
using System.Collections.Generic;
using System.Linq;
using PublicApi.v1.DTO.Identity;
using PublicApi.v1.Mappers.Identity;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class HourlyRateMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.HourlyRate))
            {
                // map internal to external
                return MapFromBLL((internalDTO.HourlyRate) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.HourlyRate))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.HourlyRate) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.HourlyRate MapFromBLL(internalDTO.HourlyRate hourlyRate)
        {
            var res = hourlyRate == null ? null : new externalDTO.HourlyRate
            {
                Id = hourlyRate.Id,
                HourRate = hourlyRate.HourRate,
                Start = hourlyRate.Start,
                End = hourlyRate.End,
            };

            return res;
        }

        public static internalDTO.HourlyRate MapFromExternal(externalDTO.HourlyRate hourlyRate)
        {
            var res = hourlyRate == null ? null : new internalDTO.HourlyRate
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