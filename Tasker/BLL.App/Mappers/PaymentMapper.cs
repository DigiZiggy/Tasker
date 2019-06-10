using System;
using BLL.App.Mappers.Identity;
using ee.itcollege.sigrid.narep.Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

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
                MeansOfPayment = payment.MeansOfPayment,
                PaymentCode = payment.PaymentCode,
                TimeOfPayment = payment.TimeOfPayment,
                Total = payment.Total,
                Comment = payment.Comment,
                InvoiceId = payment.InvoiceId,
                Invoice = InvoiceMapper.MapFromDAL(payment.Invoice)
            };

            return res;
        }

        public static DAL.App.DTO.Payment MapFromBLL(BLL.App.DTO.Payment payment)
        {
            var res = payment == null ? null : new DAL.App.DTO.Payment
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
    }
}