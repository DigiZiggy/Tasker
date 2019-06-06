using System;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO.Identity;
using AppUser = BLL.App.DTO.Identity.AppUser;

namespace BLL.App.DTO
{
    public class UserSkill
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }
        
        public DateTime End { get; set; }
        
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}