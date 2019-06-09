using System;
using BLL.App.Mappers.Identity;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class InvoiceMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.Invoice))
            {
                return MapFromDAL((DAL.App.DTO.Invoice) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.Invoice))
            {
                return MapFromBLL((BLL.App.DTO.Invoice) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.Invoice MapFromDAL(DAL.App.DTO.Invoice invoice)
        {
            var res = invoice == null ? null : new BLL.App.DTO.Invoice
            {
                Id = invoice.Id,
                InvoiceNumber = invoice.InvoiceNumber,
                Date = invoice.Date,
                TotalWithVAT = invoice.TotalWithVAT,
                TotalWithoutVAT = invoice.TotalWithoutVAT,
                VAT = invoice.VAT,
                Comment = invoice.Comment,
                AppUserId = invoice.AppUserId,
                AppUser = AppUserMapper.MapFromDAL(invoice.AppUser),
            };

            return res;
        }

        public static DAL.App.DTO.Invoice MapFromBLL(BLL.App.DTO.Invoice invoice)
        {
            var res = invoice == null ? null : new DAL.App.DTO.Invoice
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
    }
}