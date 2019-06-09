using System;
using System.Collections.Generic;
using System.Linq;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class AddressMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Address))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Address) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Address))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.Address) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Address MapFromBLL(internalDTO.Address address)
        {
            var res = address == null ? null : new externalDTO.Address
            {
                Id = address.Id,
                Country = address.Country,
                City = address.City,
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                UnitNumber = address.UnitNumber,
                PostalCode = address.PostalCode,

            };

            return res;
        }

        public static internalDTO.Address MapFromExternal(externalDTO.Address address)
        {
            var res = address == null ? null : new internalDTO.Address
            {
                Id = address.Id,
                Country = address.Country,
                City = address.City,
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                UnitNumber = address.UnitNumber,
                PostalCode = address.PostalCode,

            };
            return res;
        }
    }
}