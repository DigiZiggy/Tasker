using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Domain.Identity;

namespace Domain
{
    public class TaskerTask : DomainEntity
    {       
        public string TaskName { get; set; }       
        public string Description { get; set; }
                
//        [Required]
        public decimal TimeEstimate { get; set; }
        
        public TaskType TaskType { get; set; }

        public TaskStatus TaskStatus { get; set; }
        
        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        public List<UserTask> AppUsersInvolved { get; set; }

    }
}