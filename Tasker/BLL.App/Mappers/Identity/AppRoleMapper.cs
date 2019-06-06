using System;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers.Identity
{
    public class AppRoleMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.Identity.AppRole))
            {
                return MapFromDAL((DAL.App.DTO.Identity.AppRole) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.Identity.AppRole))
            {
                return MapFromBLL((BLL.App.DTO.Identity.AppRole) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.Identity.AppRole MapFromDAL(DAL.App.DTO.Identity.AppRole appRole)
        {
            var res = appRole == null ? null : new BLL.App.DTO.Identity.AppRole
            {
                Id = appRole.Id,

            };

            return res;
        }

        public static DAL.App.DTO.Identity.AppRole MapFromBLL(BLL.App.DTO.Identity.AppRole appRole)
        {
            var res = appRole == null ? null : new DAL.App.DTO.Identity.AppRole
            {
                Id = appRole.Id,
            };

            return res;
        }
    }
}