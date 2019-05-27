using System.Collections.Generic;
using Domain;
using Domain.Enums;

namespace DAL.App.DTO
{
    public class TaskerTaskDTO
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