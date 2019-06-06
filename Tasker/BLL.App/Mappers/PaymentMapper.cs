using System;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class PaymentMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.Payment))
            {
                return MapFromDAL((DAL.App.DTO.Payment) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.Payment))
            {
                return MapFromBLL((BLL.App.DTO.Payment) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.Payment MapFromDAL(DAL.App.DTO.Payment payment)
        {
            var res = payment == null ? null : new BLL.App.DTO.Payment
            {
                Id = payment.Id,

            };

            return res;
        }

        public static DAL.App.DTO.Payment MapFromBLL(BLL.App.DTO.Payment payment)
        {
            var res = payment == null ? null : new DAL.App.DTO.Payment
            {
                Id = payment.Id,
            };

            return res;
        }
    }
}