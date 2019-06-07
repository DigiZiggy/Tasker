using System;
using System.Collections.Generic;
using System.Linq;
using BLL.App.DTO;
using Contracts.BLL.Base.Mappers;
using DAL.App.DTO.Identity;
using AppUser = BLL.App.DTO.Identity.AppUser;

namespace BLL.App.Mappers.Identity
{
    public class AppUserMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.Identity.AppUser))
            {
                return MapFromDAL((DAL.App.DTO.Identity.AppUser) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.Identity.AppUser))
            {
                return MapFromBLL((BLL.App.DTO.Identity.AppUser) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.Identity.AppUser MapFromDAL(DAL.App.DTO.Identity.AppUser appUser)
        {
            var res = appUser == null ? null : new BLL.App.DTO.Identity.AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                SelfDescription = appUser.SelfDescription,
                HourlyRateId = appUser.HourlyRateId,
                HourlyRate = HourlyRateMapper.MapFromDAL(appUser.HourlyRate),
                Skills = appUser.Skills.Select(e => UserSkillMapper.MapFromDAL(e)) as ICollection<UserSkill>,
                TasksCreated = appUser.TasksCreated.Select(e => UserTaskMapper.MapFromDAL(e)) as ICollection<UserTask>,
                TasksWorkedOn = appUser.TasksCreated.Select(e => UserTaskMapper.MapFromDAL(e)) as ICollection<UserTask>,
                Addresses = appUser.Addresses.Select(e => UserOnAddressMapper.MapFromDAL(e)) as ICollection<UserOnAddress>,
                GivenReviews = appUser.GivenReviews.Select(e => ReviewMapper.MapFromDAL(e)) as ICollection<Review>,
                ReceivedReviews = appUser.ReceivedReviews.Select(e => ReviewMapper.MapFromDAL(e)) as ICollection<Review>,
                Invoices = appUser.Invoices.Select(e => InvoiceMapper.MapFromDAL(e)) as ICollection<Invoice>,
                Identifications = appUser.Identifications.Select(e => IdentificationMapper.MapFromDAL(e)) as ICollection<Identification>
            };

            return res;
        }

        public static DAL.App.DTO.Identity.AppUser MapFromBLL(AppUser appUser)
        {
            var res = appUser == null ? null : new DAL.App.DTO.Identity.AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                SelfDescription = appUser.SelfDescription,
                HourlyRateId = appUser.HourlyRateId,
                HourlyRate = HourlyRateMapper.MapFromBLL(appUser.HourlyRate),
                Skills = appUser.Skills.Select(e => UserSkillMapper.MapFromBLL(e)) as ICollection<DAL.App.DTO.UserSkill>,
                TasksCreated = appUser.TasksCreated.Select(e => UserTaskMapper.MapFromBLL(e)) as ICollection<DAL.App.DTO.UserTask>,
                TasksWorkedOn = appUser.TasksCreated.Select(e => UserTaskMapper.MapFromBLL(e)) as ICollection<DAL.App.DTO.UserTask>,
                Addresses = appUser.Addresses.Select(e => UserOnAddressMapper.MapFromBLL(e)) as ICollection<DAL.App.DTO.UserOnAddress>,
                GivenReviews = appUser.GivenReviews.Select(e => ReviewMapper.MapFromBLL(e)) as ICollection<DAL.App.DTO.Review>,
                ReceivedReviews = appUser.ReceivedReviews.Select(e => ReviewMapper.MapFromBLL(e)) as ICollection<DAL.App.DTO.Review>,
                Invoices = appUser.Invoices.Select(e => InvoiceMapper.MapFromBLL(e)) as ICollection<DAL.App.DTO.Invoice>,
                Identifications = appUser.Identifications.Select(e => IdentificationMapper.MapFromBLL(e)) as ICollection<DAL.App.DTO.Identification>
            };

            return res;
        }
    }
}