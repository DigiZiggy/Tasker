using System;
using ee.itcollege.sigrid.narep.Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO.Identity;
using externalDTO = BLL.App.DTO.Identity;

namespace BLL.App.Mappers.Identity
{
    public class AppUserMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject) where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.AppUser))
            {
                return MapFromDAL((internalDTO.AppUser) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AppUser))
            {
                return MapFromBLL((externalDTO.AppUser) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");

        }

        public static externalDTO.AppUser MapFromDAL(internalDTO.AppUser appUser)
        {
            var res = appUser == null ? null : new BLL.App.DTO.Identity.AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                SelfDescription = appUser.SelfDescription,
                HourlyRateId = appUser.HourlyRateId,
                HourlyRate = HourlyRateMapper.MapFromDAL(appUser.HourlyRate),
                Email = appUser.Email

            };

            return res;
        }

        public static internalDTO.AppUser MapFromBLL(externalDTO.AppUser appUser)
        {
            var res = appUser == null ? null : new DAL.App.DTO.Identity.AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                SelfDescription = appUser.SelfDescription,
                HourlyRateId = appUser.HourlyRateId,
                HourlyRate = HourlyRateMapper.MapFromBLL(appUser.HourlyRate),
                Email = appUser.Email
            };

            return res;
        }
    }
}