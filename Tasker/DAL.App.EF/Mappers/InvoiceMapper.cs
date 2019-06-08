using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;
using DAL.App.EF.Mappers.Identity;

namespace DAL.App.EF.Mappers
{
    public class InvoiceMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Invoice))
            {
                return MapFromDomain((Domain.Invoice) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Invoice))
            {
                return MapFromDAL((DAL.App.DTO.Invoice) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DAL.App.DTO.Invoice MapFromDomain(Domain.Invoice invoice)
        {
            var res = invoice == null ? null : new DAL.App.DTO.Invoice
            {
                Id = invoice.Id,
                InvoiceNumber = invoice.InvoiceNumber,
                Date = invoice.Date,
                TotalWithVAT = invoice.TotalWithVAT,
                TotalWithoutVAT = invoice.TotalWithoutVAT,
                VAT = invoice.VAT,
                Comment = invoice.Comment.Translate(),
                AppUserId = invoice.AppUserId,
                AppUser = AppUserMapper.MapFromDomain(invoice.AppUser),
                Payments = invoice.Payments.Select(e => PaymentMapper.MapFromDomain(e)) as ICollection<Payment>
            };


            return res;
        }

        public static Domain.Invoice MapFromDAL(DAL.App.DTO.Invoice invoice)
        {
            var res = invoice == null ? null : new Domain.Invoice
            {
                Id = invoice.Id,
                InvoiceNumber = invoice.InvoiceNumber,
                Date = invoice.Date,
                TotalWithVAT = invoice.TotalWithVAT,
                TotalWithoutVAT = invoice.TotalWithoutVAT,
                VAT = invoice.VAT,
                Comment = new Domain.MultiLangString(invoice.Comment),
                AppUserId = invoice.AppUserId,
                AppUser = AppUserMapper.MapFromDAL(invoice.AppUser),
                Payments = invoice.Payments.Select(e => PaymentMapper.MapFromDAL(e)) as ICollection<Domain.Payment>
            };


            return res;
        }
    }
}