using System;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class UserOnAddressMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.UserOnAddress))
            {
                return MapFromDAL((DAL.App.DTO.UserOnAddress) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.UserOnAddress))
            {
                return MapFromBLL((BLL.App.DTO.UserOnAddress) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.UserOnAddress MapFromDAL(DAL.App.DTO.UserOnAddress userOnAddress)
        {
            var res = userOnAddress == null ? null : new BLL.App.DTO.UserOnAddress
            {
                Id = userOnAddress.Id,

            };

            return res;
        }

        public static DAL.App.DTO.UserOnAddress MapFromBLL(BLL.App.DTO.UserOnAddress userOnAddress)
        {
            var res = userOnAddress == null ? null : new DAL.App.DTO.UserOnAddress
            {
                Id = userOnAddress.Id,
            };

            return res;
        }
    }
}