using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain
{
    public class Skill : DomainEntity
    {
        public string SkillName { get; set; }        
        public string Description { get; set; }  
        

        public TaskType Category { get; set; }
        
        public List<UserSkill> AppUsers { get; set; }
        
    }
}