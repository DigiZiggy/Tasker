using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;


namespace PublicApi.v1.Mappers.Identity
{
    public class AppRoleMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Identity.AppRole))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Identity.AppRole) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Identity.AppRole))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.Identity.AppRole) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Identity.AppRole MapFromBLL(internalDTO.Identity.AppRole appRole)
        {
            var res = appRole == null ? null : new externalDTO.Identity.AppRole
            {
                Id = appRole.Id,
            };

            return res;
        }

        public static internalDTO.Identity.AppRole MapFromExternal(externalDTO.Identity.AppRole appRole)
        {
            var res = appRole == null ? null : new internalDTO.Identity.AppRole
            {
                Id = appRole.Id,
            };
            return res;
        }
    }

}