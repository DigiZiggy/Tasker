using System;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class IdentificationMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Identification))
            {
                return MapFromDomain((Domain.Identification) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Identification))
            {
                return MapFromDAL((DAL.App.DTO.Identification) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DAL.App.DTO.Identification MapFromDomain(Domain.Identification identification)
        {
            var res = identification == null ? null : new DAL.App.DTO.Identification
            {
                Id = identification.Id,

            };


            return res;
        }

        public static Domain.Identification MapFromDAL(DAL.App.DTO.Identification identification)
        {
            var res = identification == null ? null : new Domain.Identification
            {
                Id = identification.Id,

            };


            return res;
        }
    }
}