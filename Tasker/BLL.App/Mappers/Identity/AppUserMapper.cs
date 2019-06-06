using System;
using Contracts.BLL.Base.Mappers;
using DAL.App.DTO.Identity;
using AppUser = BLL.App.DTO.Identity.AppUser;

namespace BLL.App.Mappers.Identity
{
    public class AppUserMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.Identity.AppUser))
            {
                return MapFromDAL((DAL.App.DTO.Identity.AppUser) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.Identity.AppUser))
            {
                return MapFromBLL((BLL.App.DTO.Identity.AppUser) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.Identity.AppUser MapFromDAL(DAL.App.DTO.Identity.AppUser appUser)
        {
            var res = appUser == null ? null : new BLL.App.DTO.Identity.AppUser
            {
                Id = appUser.Id,

            };

            return res;
        }

        public static DAL.App.DTO.Identity.AppUser MapFromBLL(AppUser appUser)
        {
            var res = appUser == null ? null : new DAL.App.DTO.Identity.AppUser
            {
                Id = appUser.Id,
            };

            return res;
        }
    }
}