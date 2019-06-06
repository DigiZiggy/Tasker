using System;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class SkillMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Skill))
            {
                return MapFromDomain((Domain.Skill) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Skill))
            {
                return MapFromDAL((DAL.App.DTO.Skill) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DAL.App.DTO.Skill MapFromDomain(Domain.Skill skill)
        {
            var res = skill == null ? null : new DAL.App.DTO.Skill
            {
                Id = skill.Id,

            };


            return res;
        }

        public static Domain.Skill MapFromDAL(DAL.App.DTO.Skill skill)
        {
            var res = skill == null ? null : new Domain.Skill
            {
                Id = skill.Id,

            };


            return res;
        }
    }
}