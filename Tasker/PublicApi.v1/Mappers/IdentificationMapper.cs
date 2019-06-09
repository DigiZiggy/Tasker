using System;
using PublicApi.v1.Mappers.Identity;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class IdentificationMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Identification))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Identification) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Identification))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.Identification) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Identification MapFromBLL(internalDTO.Identification identification)
        {
            var res = identification == null ? null : new externalDTO.Identification
            {
                Id = identification.Id,
                DocNumber = identification.DocNumber,
                Start = identification.Start,
                End = identification.End,
                Comment = identification.Comment,
                AppUserId = identification.AppUserId,
                AppUser = AppUserMapper.MapFromBLL(identification.AppUser)
            };

            return res;
        }

        public static internalDTO.Identification MapFromExternal(externalDTO.Identification identification)
        {
            var res = identification == null ? null : new internalDTO.Identification
            {
                Id = identification.Id,
                DocNumber = identification.DocNumber,
                Start = identification.Start,
                End = identification.End,
                Comment = identification.Comment,
                AppUserId = identification.AppUserId,
                AppUser = AppUserMapper.MapFromExternal(identification.AppUser)               
            };
            return res;
        }
    }
}