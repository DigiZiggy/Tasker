using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO.Enums;
using DAL.App.DTO.Identity;


namespace BLL.App.DTO
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