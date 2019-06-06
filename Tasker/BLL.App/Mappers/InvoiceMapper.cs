using System;
using Contracts.BLL.Base.Mappers;

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

            };

            return res;
        }

        public static DAL.App.DTO.Invoice MapFromBLL(BLL.App.DTO.Invoice invoice)
        {
            var res = invoice == null ? null : new DAL.App.DTO.Invoice
            {
                Id = invoice.Id,
            };

            return res;
        }
    }
}