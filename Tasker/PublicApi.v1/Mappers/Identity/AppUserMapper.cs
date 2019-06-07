using System;
using System.Collections.Generic;
using System.Linq;
using internalDTO = BLL.App.DTO;
using externalDTO = PublicApi.v1.DTO;


namespace PublicApi.v1.Mappers.Identity
{
    public class AppUserMapper 
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Identity.AppUser))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Identity.AppUser) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Identity.AppUser))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.Identity.AppUser) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Identity.AppUser MapFromBLL(internalDTO.Identity.AppUser appUser)
        {
            var res = appUser == null ? null : new externalDTO.Identity.AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                SelfDescription = appUser.SelfDescription,
                HourlyRateId = appUser.HourlyRateId,
                HourlyRate = HourlyRateMapper.MapFromBLL(appUser.HourlyRate),
                Skills = appUser.Skills.Select(e => UserSkillMapper.MapFromBLL(e)) as ICollection<externalDTO.UserSkill>,
                TasksCreated = appUser.TasksCreated.Select(e => UserTaskMapper.MapFromBLL(e)) as ICollection<externalDTO.UserTask>,
                TasksWorkedOn = appUser.TasksCreated.Select(e => UserTaskMapper.MapFromBLL(e)) as ICollection<externalDTO.UserTask>,
                Addresses = appUser.Addresses.Select(e => UserOnAddressMapper.MapFromBLL(e)) as ICollection<externalDTO.UserOnAddress>,
                GivenReviews = appUser.GivenReviews.Select(e => ReviewMapper.MapFromBLL(e)) as ICollection<externalDTO.Review>,
                ReceivedReviews = appUser.ReceivedReviews.Select(e => ReviewMapper.MapFromBLL(e)) as ICollection<externalDTO.Review>,
                Invoices = appUser.Invoices.Select(e => InvoiceMapper.MapFromBLL(e)) as ICollection<externalDTO.Invoice>,
                Identifications = appUser.Identifications.Select(e => IdentificationMapper.MapFromBLL(e)) as ICollection<externalDTO.Identification>
            };

            return res;
        }

        public static internalDTO.Identity.AppUser MapFromExternal(externalDTO.Identity.AppUser appUser)
        {
            var res = appUser == null ? null : new internalDTO.Identity.AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                SelfDescription = appUser.SelfDescription,
                HourlyRateId = appUser.HourlyRateId,
                HourlyRate = HourlyRateMapper.MapFromExternal(appUser.HourlyRate),
                Skills = appUser.Skills.Select(e => UserSkillMapper.MapFromExternal(e)) as ICollection<internalDTO.UserSkill>,
                TasksCreated = appUser.TasksCreated.Select(e => UserTaskMapper.MapFromExternal(e)) as ICollection<internalDTO.UserTask>,
                TasksWorkedOn = appUser.TasksCreated.Select(e => UserTaskMapper.MapFromExternal(e)) as ICollection<internalDTO.UserTask>,
                Addresses = appUser.Addresses.Select(e => UserOnAddressMapper.MapFromExternal(e)) as ICollection<internalDTO.UserOnAddress>,
                GivenReviews = appUser.GivenReviews.Select(e => ReviewMapper.MapFromExternal(e)) as ICollection<internalDTO.Review>,
                ReceivedReviews = appUser.ReceivedReviews.Select(e => ReviewMapper.MapFromExternal(e)) as ICollection<internalDTO.Review>,
                Invoices = appUser.Invoices.Select(e => InvoiceMapper.MapFromExternal(e)) as ICollection<internalDTO.Invoice>,
                Identifications = appUser.Identifications.Select(e => IdentificationMapper.MapFromExternal(e)) as ICollection<internalDTO.Identification>
            };
            return res;
        }
    }
}