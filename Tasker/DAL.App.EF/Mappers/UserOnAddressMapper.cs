using System;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class UserOnAddressMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.UserOnAddress))
            {
                return MapFromDomain((Domain.UserOnAddress) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.UserOnAddress))
            {
                return MapFromDAL((DAL.App.DTO.UserOnAddress) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DAL.App.DTO.UserOnAddress MapFromDomain(Domain.UserOnAddress userOnAddress)
        {
            var res = userOnAddress == null ? null : new DAL.App.DTO.UserOnAddress
            {
                Id = userOnAddress.Id,

            };


            return res;
        }

        public static Domain.UserOnAddress MapFromDAL(DAL.App.DTO.UserOnAddress userOnAddress)
        {
            var res = userOnAddress == null ? null : new Domain.UserOnAddress
            {
                Id = userOnAddress.Id,

            };


            return res;
        }
    }
}