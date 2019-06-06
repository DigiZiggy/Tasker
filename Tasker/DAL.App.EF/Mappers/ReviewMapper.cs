using System;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class ReviewMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Review))
            {
                return MapFromDomain((Domain.Review) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Review))
            {
                return MapFromDAL((DAL.App.DTO.Review) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DAL.App.DTO.Review MapFromDomain(Domain.Review review)
        {
            var res = review == null ? null : new DAL.App.DTO.Review
            {
                Id = review.Id,

            };


            return res;
        }

        public static Domain.Review MapFromDAL(DAL.App.DTO.Review review)
        {
            var res = review == null ? null : new Domain.Review
            {
                Id = review.Id,

            };


            return res;
        }
    }
}