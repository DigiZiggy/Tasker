using System.Collections.Generic;
using DAL.App.DTO.Enums;


namespace DAL.App.DTO
{
    public class Skill
    {
        public int Id { get; set; }

        public string SkillName { get; set; }
        
        public string Description { get; set; }  
        
        public TaskType Category { get; set; }
        
        public ICollection<UserSkill> AppUsers { get; set; }
    }
}