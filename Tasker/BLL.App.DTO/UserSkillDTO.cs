using System;
using Domain;
using Domain.Identity;

namespace DAL.App.DTO
{
    public class UserSkillDTO
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