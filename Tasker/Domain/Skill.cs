using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain
{
    public class Skill : DomainEntity
    {
        [ForeignKey(nameof(SkillName))]
        public int SkillNameId { get; set; }
        public MultiLangString SkillName { get; set; }
        
        [ForeignKey(nameof(Description))]
        public int DescriptionId { get; set; }
        public MultiLangString Description { get; set; }  
        

        public TaskType Category { get; set; }
        
        public List<UserSkill> AppUsers { get; set; }
        
    }
}