using System;
using Contracts.BLL.Base.Mappers;

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

            };

            return res;
        }

        public static DAL.App.DTO.UserSkill MapFromBLL(BLL.App.DTO.UserSkill userSkill)
        {
            var res = userSkill == null ? null : new DAL.App.DTO.UserSkill
            {
                Id = userSkill.Id,
            };

            return res;
        }
    }
}