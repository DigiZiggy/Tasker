using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;
using DAL.App.DTO.Identity;
using DAL.App.EF.Mappers.Identity;

namespace DAL.App.EF.Mappers
{
    public class HourlyRateMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.HourlyRate))
            {
                return MapFromDomain((Domain.HourlyRate) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.HourlyRate))
            {
                return MapFromDAL((DAL.App.DTO.HourlyRate) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DAL.App.DTO.HourlyRate MapFromDomain(Domain.HourlyRate hourlyRate)
        {
            var res = hourlyRate == null ? null : new DAL.App.DTO.HourlyRate
            {
                Id = hourlyRate.Id,
                HourRate = hourlyRate.HourRate,
                Start = hourlyRate.Start,
                End = hourlyRate.End,
                AppUsers = hourlyRate.AppUsers.Select(e => AppUserMapper.MapFromDomain(e)) as ICollection<AppUser>
            };


            return res;
        }

        public static Domain.HourlyRate MapFromDAL(DAL.App.DTO.HourlyRate hourlyRate)
        {
            var res = hourlyRate == null ? null : new Domain.HourlyRate
            {
                Id = hourlyRate.Id,
                HourRate = hourlyRate.HourRate,
                Start = hourlyRate.Start,
                End = hourlyRate.End,
                AppUsers = hourlyRate.AppUsers.Select(e => AppUserMapper.MapFromDAL(e)) as ICollection<Domain.Identity.AppUser>
            };


            return res;
        }
    }
}