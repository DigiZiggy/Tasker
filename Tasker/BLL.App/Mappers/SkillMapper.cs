using System;
using BLL.App.Mappers.Identity;
using ee.itcollege.sigrid.narep.Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class SkillMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.Skill))
            {
                return MapFromDAL((DAL.App.DTO.Skill) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.Skill))
            {
                return MapFromBLL((BLL.App.DTO.Skill) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.Skill MapFromDAL(DAL.App.DTO.Skill skill)
        {
            var res = skill == null ? null : new BLL.App.DTO.Skill
            {
                Id = skill.Id,
                SkillName = skill.SkillName,
                Description = skill.Description,
            };

            return res;
        }

        public static DAL.App.DTO.Skill MapFromBLL(BLL.App.DTO.Skill skill)
        {
            var res = skill == null ? null : new DAL.App.DTO.Skill
            {
                Id = skill.Id,
                SkillName = skill.SkillName,
                Description = skill.Description,
            };

            return res;
        }
    }
}