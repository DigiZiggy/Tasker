using System;
using PublicApi.v1.Mappers.Identity;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class UserOnAddressMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.UserOnAddress))
            {
                // map internal to external
                return MapFromBLL((internalDTO.UserOnAddress) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.UserOnAddress))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.UserOnAddress) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.UserOnAddress MapFromBLL(internalDTO.UserOnAddress userOnAddress)
        {
            var res = userOnAddress == null ? null : new externalDTO.UserOnAddress
            {
                Id = userOnAddress.Id,
                Start = userOnAddress.Start,
                End = userOnAddress.End,
                AddressId = userOnAddress.AddressId,
                AppUserId = userOnAddress.AppUserId,
                Address = AddressMapper.MapFromBLL(userOnAddress.Address),
                AppUser = AppUserMapper.MapFromBLL(userOnAddress.AppUser)
            };

            return res;
        }

        public static internalDTO.UserOnAddress MapFromExternal(externalDTO.UserOnAddress userOnAddress)
        {
            var res = userOnAddress == null ? null : new internalDTO.UserOnAddress
            {
                Id = userOnAddress.Id,
                Start = userOnAddress.Start,
                End = userOnAddress.End,
                AddressId = userOnAddress.AddressId,
                AppUserId = userOnAddress.AppUserId,
                Address = AddressMapper.MapFromExternal(userOnAddress.Address),
                AppUser = AppUserMapper.MapFromExternal(userOnAddress.AppUser)
            };
            return res;
        }
    }
}