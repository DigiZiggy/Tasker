using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskType = BLL.App.DTO.Enums.TaskType;


namespace BLL.App.DTO
{
    public class Skill
    {
        public int Id { get; set; }

        [Display(Name = nameof(SkillName), ResourceType = typeof(Resources.Domain.Skill))]
        public string SkillName { get; set; }
        
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.Skill))]
        public string Description { get; set; }  
        
        [Display(Name = nameof(Category), ResourceType = typeof(Resources.Domain.Skill))]
        public TaskType Category { get; set; }
        
    }
}