using System;
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

            };

            return res;
        }

        public static DAL.App.DTO.Address MapFromBLL(BLL.App.DTO.Address address)
        {
            var res = address == null ? null : new DAL.App.DTO.Address
            {
                Id = address.Id,
            };
            
            return res;
        }
    }
}