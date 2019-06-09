using System;
using System.Collections.Generic;
using System.Linq;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class SkillMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Skill))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Skill) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Skill))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.Skill) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Skill MapFromBLL(internalDTO.Skill skill)
        {
            var res = skill == null ? null : new externalDTO.Skill
            {
                Id = skill.Id,
                SkillName = skill.SkillName,
                Description = skill.Description,
            };

            return res;
        }

        public static internalDTO.Skill MapFromExternal(externalDTO.Skill skill)
        {
            var res = skill == null ? null : new internalDTO.Skill
            {
                Id = skill.Id,
                SkillName = skill.SkillName,
                Description = skill.Description,
            };
            return res;
        }
    }
}