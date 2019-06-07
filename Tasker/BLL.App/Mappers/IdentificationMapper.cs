using System;
using BLL.App.Mappers.Identity;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class IdentificationMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.Identification))
            {
                return MapFromDAL((DAL.App.DTO.Identification) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.Identification))
            {
                return MapFromBLL((BLL.App.DTO.Identification) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.Identification MapFromDAL(DAL.App.DTO.Identification identification)
        {
            var res = identification == null ? null : new BLL.App.DTO.Identification
            {
                Id = identification.Id,
                DocNumber = identification.DocNumber,
                Start = identification.Start,
                End = identification.End,
                AppUserId = identification.AppUserId,
                AppUser = AppUserMapper.MapFromDAL(identification.AppUser)
            };

            return res;
        }

        public static DAL.App.DTO.Identification MapFromBLL(BLL.App.DTO.Identification identification)
        {
            var res = identification == null ? null : new DAL.App.DTO.Identification
            {
                Id = identification.Id,
                DocNumber = identification.DocNumber,
                Start = identification.Start,
                End = identification.End,
                AppUserId = identification.AppUserId,
                AppUser = AppUserMapper.MapFromBLL(identification.AppUser)               
            };

            return res;
        }
    }
}