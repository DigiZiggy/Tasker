using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class PaymentMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Payment))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Payment) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Payment))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.Payment) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Payment MapFromBLL(internalDTO.Payment payment)
        {
            var res = payment == null ? null : new externalDTO.Payment
            {
                Id = payment.Id,
                MeansOfPayment = payment.MeansOfPayment,
                PaymentCode = payment.PaymentCode,
                TimeOfPayment = payment.TimeOfPayment,
                Total = payment.Total,
                Comment = payment.Comment,
                InvoiceId = payment.InvoiceId,
                Invoice = InvoiceMapper.MapFromBLL(payment.Invoice)
            };

            return res;
        }

        public static internalDTO.Payment MapFromExternal(externalDTO.Payment payment)
        {
            var res = payment == null ? null : new internalDTO.Payment
            {
                Id = payment.Id,
                MeansOfPayment = payment.MeansOfPayment,
                PaymentCode = payment.PaymentCode,
                TimeOfPayment = payment.TimeOfPayment,
                Total = payment.Total,
                Comment = payment.Comment,
                InvoiceId = payment.InvoiceId,
                Invoice = InvoiceMapper.MapFromExternal(payment.Invoice)
            };
            return res;
        }
    }
}