using System;
using BLL.App.Mappers.Identity;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class AddressMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Address))
            {
                return MapFromDAL((internalDTO.Address) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Address))
            {
                return MapFromBLL((externalDTO.Address) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Address MapFromDAL(internalDTO.Address address)
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

        public static internalDTO.Address MapFromBLL(externalDTO.Address address)
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