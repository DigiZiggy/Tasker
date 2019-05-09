using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Domain.Enums;

namespace Domain
{
    public class Skill : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string SkillName { get; set; }
        public string Description { get; set; }       
        public TaskType Category { get; set; }
        
        public ICollection<UserSkill> AppUsers { get; set; }
        
    }
}