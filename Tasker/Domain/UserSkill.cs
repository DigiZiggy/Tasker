using System;
using Domain.Identity;

namespace Domain
{
    public class UserSkill : DomainEntity
    {
//        [Required]
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }

}