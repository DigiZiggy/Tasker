using System;
using PublicApi.v1.Mappers.Identity;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class UserSkillMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.UserSkill))
            {
                // map internal to external
                return MapFromBLL((internalDTO.UserSkill) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.UserSkill))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.UserSkill) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.UserSkill MapFromBLL(internalDTO.UserSkill userSkill)
        {
            var res = userSkill == null ? null : new externalDTO.UserSkill
            {
                Id = userSkill.Id,
                Start = userSkill.Start,
                End = userSkill.End,
                SkillId = userSkill.SkillId,
                AppUserId = userSkill.AppUserId,
                Skill = SkillMapper.MapFromBLL(userSkill.Skill),
                AppUser = AppUserMapper.MapFromBLL(userSkill.AppUser)
            };

            return res;
        }

        public static internalDTO.UserSkill MapFromExternal(externalDTO.UserSkill userSkill)
        {
            var res = userSkill == null ? null : new internalDTO.UserSkill
            {
                Id = userSkill.Id,
                Start = userSkill.Start,
                End = userSkill.End,
                SkillId = userSkill.SkillId,
                AppUserId = userSkill.AppUserId,
                Skill = SkillMapper.MapFromExternal(userSkill.Skill),
                AppUser = AppUserMapper.MapFromExternal(userSkill.AppUser)
            };
            return res;
        }
    }
}