using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskStatus = BLL.App.DTO.Enums.TaskStatus;
using TaskType = BLL.App.DTO.Enums.TaskType;


namespace BLL.App.DTO
{
    public class TaskerTask
    {
        public int Id { get; set; }

        [Display(Name = nameof(TaskName), ResourceType = typeof(Resources.Domain.TaskerTask))]
        public string TaskName { get; set; }
        
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.TaskerTask))]
        public string Description { get; set; }
        
        [Display(Name = nameof(TimeEstimate), ResourceType = typeof(Resources.Domain.TaskerTask))]
        public decimal TimeEstimate { get; set; }               
        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        [Display(Name = nameof(TaskType), ResourceType = typeof(Resources.Domain.TaskerTask))]
        public TaskType TaskType { get; set; }

        [Display(Name = nameof(TaskStatus), ResourceType = typeof(Resources.Domain.TaskerTask))]
        public TaskStatus TaskStatus { get; set; }
    }
}