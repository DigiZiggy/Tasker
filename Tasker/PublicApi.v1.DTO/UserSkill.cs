using System;
using PublicApi.v1.DTO.Identity;

namespace PublicApi.v1.DTO
{
    public class UserSkill
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}