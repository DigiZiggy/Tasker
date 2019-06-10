using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskType = BLL.App.DTO.Enums.TaskType;


namespace BLL.App.DTO
{
    public class Skill
    {
        public int Id { get; set; }

        public string SkillName { get; set; }
        
        public string Description { get; set; }  
        
        public TaskType Category { get; set; }
        
    }
}