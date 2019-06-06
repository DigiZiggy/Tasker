using System;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class PaymentMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Payment))
            {
                return MapFromDomain((Domain.Payment) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Payment))
            {
                return MapFromDAL((DAL.App.DTO.Payment) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DAL.App.DTO.Payment MapFromDomain(Domain.Payment payment)
        {
            var res = payment == null ? null : new DAL.App.DTO.Payment
            {
                Id = payment.Id,

            };


            return res;
        }

        public static Domain.Payment MapFromDAL(DAL.App.DTO.Payment payment)
        {
            var res = payment == null ? null : new Domain.Payment
            {
                Id = payment.Id,

            };


            return res;
        }
    }
}