using System;
using ee.itcollege.sigrid.narep.Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO.Identity;
using externalDTO = BLL.App.DTO.Identity;

namespace BLL.App.Mappers.Identity
{
    public class AppRoleMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject) where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.AppRole))
            {
                return MapFromDAL((internalDTO.AppRole) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AppRole))
            {
                return MapFromBLL((externalDTO.AppRole) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");

        }
        
        public static externalDTO.AppRole MapFromDAL(internalDTO.AppRole appRole)
        {
            var res = appRole == null ? null : new externalDTO.AppRole
            {
                Id = appRole.Id,
            };

            return res;
        }

        public static internalDTO.AppRole MapFromBLL(externalDTO.AppRole appRole)
        {
            var res = appRole == null ? null : new internalDTO.AppRole
            {
                Id = appRole.Id,
            };

            return res;
        }
    }
}