using System;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class UserSkillMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.UserSkill))
            {
                return MapFromDomain((Domain.UserSkill) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.UserSkill))
            {
                return MapFromDAL((DAL.App.DTO.UserSkill) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DAL.App.DTO.UserSkill MapFromDomain(Domain.UserSkill userSkill)
        {
            var res = userSkill == null ? null : new DAL.App.DTO.UserSkill
            {
                Id = userSkill.Id,

            };


            return res;
        }

        public static Domain.UserSkill MapFromDAL(DAL.App.DTO.UserSkill userSkill)
        {
            var res = userSkill == null ? null : new Domain.UserSkill
            {
                Id = userSkill.Id,

            };


            return res;
        }
    }
}