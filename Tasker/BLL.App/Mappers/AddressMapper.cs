using System;
using System.Collections.Generic;
using System.Linq;
using BLL.App.DTO;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class AddressMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.Address))
            {
                return MapFromDAL((DAL.App.DTO.Address) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.Address))
            {
                return MapFromBLL((BLL.App.DTO.Address) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.Address MapFromDAL(DAL.App.DTO.Address address)
        {
            var res = address == null ? null : new BLL.App.DTO.Address
            {
                Id = address.Id,
                Country = address.Country,
                City = address.City,
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                UnitNumber = address.UnitNumber,
                PostalCode = address.PostalCode,
                AppUsersOnAddress = address.AppUsersOnAddress.Select(e => UserOnAddressMapper.MapFromDAL(e)) as ICollection<UserOnAddress>,
                TasksOnAddress = address.TasksOnAddress.Select(e => TaskerTaskMapper.MapFromDAL(e)) as ICollection<TaskerTask>
            };

            return res;
        }

        public static DAL.App.DTO.Address MapFromBLL(BLL.App.DTO.Address address)
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
                AppUsersOnAddress = address.AppUsersOnAddress.Select(e => UserOnAddressMapper.MapFromBLL(e)) as ICollection<DAL.App.DTO.UserOnAddress>,
                TasksOnAddress = address.TasksOnAddress.Select(e => TaskerTaskMapper.MapFromBLL(e)) as ICollection<DAL.App.DTO.TaskerTask>
            };
            
            return res;
        }
    }
}