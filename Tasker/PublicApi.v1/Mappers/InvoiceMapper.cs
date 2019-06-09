using System;
using System.Collections.Generic;
using System.Linq;
using PublicApi.v1.Mappers.Identity;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class InvoiceMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Invoice))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Invoice) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Invoice))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.Invoice) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Invoice MapFromBLL(internalDTO.Invoice invoice)
        {
            var res = invoice == null ? null : new externalDTO.Invoice
            {
                Id = invoice.Id,
                InvoiceNumber = invoice.InvoiceNumber,
                Date = invoice.Date,
                TotalWithVAT = invoice.TotalWithVAT,
                TotalWithoutVAT = invoice.TotalWithoutVAT,
                VAT = invoice.VAT,
                Comment = invoice.Comment,
                AppUserId = invoice.AppUserId,
                AppUser = AppUserMapper.MapFromBLL(invoice.AppUser),
            };

            return res;
        }

        public static internalDTO.Invoice MapFromExternal(externalDTO.Invoice invoice)
        {
            var res = invoice == null ? null : new internalDTO.Invoice
            {
                Id = invoice.Id,
                InvoiceNumber = invoice.InvoiceNumber,
                Date = invoice.Date,
                TotalWithVAT = invoice.TotalWithVAT,
                TotalWithoutVAT = invoice.TotalWithoutVAT,
                VAT = invoice.VAT,
                Comment = invoice.Comment,
                AppUserId = invoice.AppUserId,
                AppUser = AppUserMapper.MapFromExternal(invoice.AppUser),
            };
            return res;
        }
    }
}