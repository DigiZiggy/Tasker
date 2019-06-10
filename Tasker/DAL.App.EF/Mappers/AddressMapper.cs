using System;
using System.Collections.Generic;
using System.Linq;
using DAL.App.DTO;
using ee.itcollege.sigrid.narep.Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class AddressMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Address))
            {
                return MapFromDomain((Domain.Address) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Address))
            {
                return MapFromDAL((DAL.App.DTO.Address) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DAL.App.DTO.Address MapFromDomain(Domain.Address address)
        {
            var res = address == null ? null : new DAL.App.DTO.Address
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

        public static Domain.Address MapFromDAL(DAL.App.DTO.Address address)
        {
            var res = address == null ? null : new Domain.Address
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