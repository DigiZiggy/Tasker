using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

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
                AppUsersOnAddress = address.AppUsersOnAddress.Select(e => UserOnAddressMapper.MapFromDomain(e)) as ICollection<UserOnAddress>,
                TasksOnAddress = address.TasksOnAddress.Select(e => TaskerTaskMapper.MapFromDomain(e)) as ICollection<TaskerTask>
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
                AppUsersOnAddress = address.AppUsersOnAddress.Select(e => UserOnAddressMapper.MapFromDAL(e)) as ICollection<Domain.UserOnAddress>,
                TasksOnAddress = address.TasksOnAddress.Select(e => TaskerTaskMapper.MapFromDAL(e)) as ICollection<Domain.TaskerTask>
            };


            return res;
        }
    }
}