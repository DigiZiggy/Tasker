using System;
using DAL.App.DTO;
using ee.itcollege.sigrid.narep.Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers.Identity
{
    public class AppRoleMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Identity.AppRole))
            {
                return MapFromDomain((Domain.Identity.AppRole) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Identity.AppRole))
            {
                return MapFromDAL((DAL.App.DTO.Identity.AppRole) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DAL.App.DTO.Identity.AppRole MapFromDomain(Domain.Identity.AppRole appRole)
        {
            var res = appRole == null ? null : new DAL.App.DTO.Identity.AppRole
            {
                Id = appRole.Id,

            };


            return res;
        }

        public static Domain.Identity.AppRole MapFromDAL(DAL.App.DTO.Identity.AppRole appRole)
        {
            var res = appRole == null ? null : new Domain.Identity.AppRole
            {
                Id = appRole.Id,

            };


            return res;
        }
    }
}