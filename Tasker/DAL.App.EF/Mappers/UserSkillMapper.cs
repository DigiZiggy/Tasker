using System;
using DAL.App.DTO;
using DAL.App.EF.Mappers.Identity;
using ee.itcollege.sigrid.narep.Contracts.DAL.Base.Mappers;

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
                Start = userSkill.Start,
                End = userSkill.End,
                SkillId = userSkill.SkillId,
                AppUserId = userSkill.AppUserId,
                Skill = SkillMapper.MapFromDomain(userSkill.Skill),
                AppUser = AppUserMapper.MapFromDomain(userSkill.AppUser)
            };


            return res;
        }

        public static Domain.UserSkill MapFromDAL(DAL.App.DTO.UserSkill userSkill)
        {
            var res = userSkill == null ? null : new Domain.UserSkill
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
    }
}