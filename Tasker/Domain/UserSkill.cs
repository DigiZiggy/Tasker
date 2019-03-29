using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication.ExtendedProtection;
using Domain.Identity;

namespace Domain
{
    public class UserSkill : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string Name { get; set; }
        
//        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Comment { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}