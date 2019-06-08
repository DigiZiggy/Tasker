using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers.Identity
{
    public class AppUserMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DAL.App.DTO.Identity.AppUser))
            {
                return MapFromDomain((Domain.Identity.AppUser) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Identity.AppUser))
            {
                return MapFromDAL((DAL.App.DTO.Identity.AppUser) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DAL.App.DTO.Identity.AppUser MapFromDomain(Domain.Identity.AppUser appUser)
        {
            var res = appUser == null ? null : new DAL.App.DTO.Identity.AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                SelfDescription = appUser.SelfDescription.Translate(),
                HourlyRateId = appUser.HourlyRateId,
                HourlyRate = HourlyRateMapper.MapFromDomain(appUser.HourlyRate),
                Skills = appUser.Skills.Select(e => UserSkillMapper.MapFromDomain(e)) as ICollection<UserSkill>,
                TasksCreated = appUser.TasksCreated.Select(e => UserTaskMapper.MapFromDomain(e)) as ICollection<UserTask>,
                TasksWorkedOn = appUser.TasksCreated.Select(e => UserTaskMapper.MapFromDomain(e)) as ICollection<UserTask>,
                Addresses = appUser.Addresses.Select(e => UserOnAddressMapper.MapFromDomain(e)) as ICollection<UserOnAddress>,
                GivenReviews = appUser.GivenReviews.Select(e => ReviewMapper.MapFromDomain(e)) as ICollection<Review>,
                ReceivedReviews = appUser.ReceivedReviews.Select(e => ReviewMapper.MapFromDomain(e)) as ICollection<Review>,
                Invoices = appUser.Invoices.Select(e => InvoiceMapper.MapFromDomain(e)) as ICollection<Invoice>,
                Identifications = appUser.Identifications.Select(e => IdentificationMapper.MapFromDomain(e)) as ICollection<Identification>
            };


            return res;
        }

        public static Domain.Identity.AppUser MapFromDAL(DAL.App.DTO.Identity.AppUser appUser)
        {
            var res = appUser == null ? null : new Domain.Identity.AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                SelfDescription = new Domain.MultiLangString(appUser.SelfDescription),
                HourlyRateId = appUser.HourlyRateId,
                HourlyRate = HourlyRateMapper.MapFromDAL(appUser.HourlyRate),
                Skills = appUser.Skills.Select(e => UserSkillMapper.MapFromDAL(e)) as ICollection<Domain.UserSkill>,
                TasksCreated = appUser.TasksCreated.Select(e => UserTaskMapper.MapFromDAL(e)) as ICollection<Domain.UserTask>,
                TasksWorkedOn = appUser.TasksCreated.Select(e => UserTaskMapper.MapFromDAL(e)) as ICollection<Domain.UserTask>,
                Addresses = appUser.Addresses.Select(e => UserOnAddressMapper.MapFromDAL(e)) as ICollection<Domain.UserOnAddress>,
                GivenReviews = appUser.GivenReviews.Select(e => ReviewMapper.MapFromDAL(e)) as ICollection<Domain.Review>,
                ReceivedReviews = appUser.ReceivedReviews.Select(e => ReviewMapper.MapFromDAL(e)) as ICollection<Domain.Review>,
                Invoices = appUser.Invoices.Select(e => InvoiceMapper.MapFromDAL(e)) as ICollection<Domain.Invoice>,
                Identifications = appUser.Identifications.Select(e => IdentificationMapper.MapFromDAL(e)) as ICollection<Domain.Identification>
            };


            return res;
        }
    }
}