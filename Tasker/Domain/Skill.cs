using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using Domain.Base;
using Domain.Enums;

namespace Domain
{
    public class Skill : BaseEntity, IDomainEntity
    {
        [ForeignKey(nameof(SkillName))]
        public int SkillNameId { get; set; }
        public MultiLangString SkillName { get; set; }
        
        [ForeignKey(nameof(Description))]
        public int DescriptionId { get; set; }
        public MultiLangString Description { get; set; }  
        


        public TaskType Category { get; set; }
        
        public ICollection<UserSkill> AppUsers { get; set; }
        
    }
}