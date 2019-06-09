using System;
using BLL.App.Mappers.Identity;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class UserSkillMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.UserSkill))
            {
                return MapFromDAL((DAL.App.DTO.UserSkill) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.UserSkill))
            {
                return MapFromBLL((BLL.App.DTO.UserSkill) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.UserSkill MapFromDAL(DAL.App.DTO.UserSkill userSkill)
        {
            var res = userSkill == null ? null : new BLL.App.DTO.UserSkill
            {
                Id = userSkill.Id,
                Start = userSkill.Start,
                End = userSkill.End,
                SkillId = userSkill.SkillId,
                AppUserId = userSkill.AppUserId,
                Skill = SkillMapper.MapFromDAL(userSkill.Skill),
                AppUser = AppUserMapper.MapFromDAL(userSkill.AppUser)
            };

            return res;
        }

        public static DAL.App.DTO.UserSkill MapFromBLL(BLL.App.DTO.UserSkill userSkill)
        {
            var res = userSkill == null ? null : new DAL.App.DTO.UserSkill
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
    }
}