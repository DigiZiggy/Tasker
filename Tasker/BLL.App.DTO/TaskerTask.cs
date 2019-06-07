using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO.Enums;
using DAL.App.DTO.Identity;
using TaskStatus = BLL.App.DTO.Enums.TaskStatus;
using TaskType = BLL.App.DTO.Enums.TaskType;


namespace BLL.App.DTO
{
    public class TaskerTask
    {
        public int Id { get; set; }

        public string TaskName { get; set; }
        
        public string Description { get; set; }
        
        public decimal TimeEstimate { get; set; }
        
        public TaskType TaskType { get; set; }

        public TaskStatus TaskStatus { get; set; }
        
        public ICollection<UserTask> AppUsersInvolved { get; set; }
        
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}