using System;
using PublicApi.v1.Mappers.Identity;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ReviewMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Review))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Review) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Review))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.Review) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Review MapFromBLL(internalDTO.Review review)
        {
            var res = review == null ? null : new externalDTO.Review
            {
                Id = review.Id,
                Rating = review.Rating,
                ReviewComment = review.ReviewComment,
                ReviewGiverId = review.ReviewGiverId,
                ReviewReceiverId = review.ReviewReceiverId,
                ReviewGiver = AppUserMapper.MapFromBLL(review.ReviewGiver),
                ReviewReceiver = AppUserMapper.MapFromBLL(review.ReviewReceiver)
            };

            return res;
        }

        public static internalDTO.Review MapFromExternal(externalDTO.Review review)
        {
            var res = review == null ? null : new internalDTO.Review
            {
                Id = review.Id,
                Rating = review.Rating,
                ReviewComment = review.ReviewComment,
                ReviewGiverId = review.ReviewGiverId,
                ReviewReceiverId = review.ReviewReceiverId,
                ReviewGiver = AppUserMapper.MapFromExternal(review.ReviewGiver),
                ReviewReceiver = AppUserMapper.MapFromExternal(review.ReviewReceiver)
            };
            return res;
        }
    }
}