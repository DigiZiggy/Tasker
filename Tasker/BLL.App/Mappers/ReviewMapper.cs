using System;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class ReviewMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.Review))
            {
                return MapFromDAL((DAL.App.DTO.Review) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.Review))
            {
                return MapFromBLL((BLL.App.DTO.Review) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.Review MapFromDAL(DAL.App.DTO.Review review)
        {
            var res = review == null ? null : new BLL.App.DTO.Review
            {
                Id = review.Id,

            };

            return res;
        }

        public static DAL.App.DTO.Review MapFromBLL(BLL.App.DTO.Review review)
        {
            var res = review == null ? null : new DAL.App.DTO.Review
            {
                Id = review.Id,
            };

            return res;
        }
    }
}