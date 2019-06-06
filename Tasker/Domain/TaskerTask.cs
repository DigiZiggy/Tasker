using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using Domain.Base;
using Domain.Enums;
using Domain.Identity;

namespace Domain
{
    public class TaskerTask : BaseEntity, IDomainEntity
    {       
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string TaskName { get; set; }
        
        [MaxLength(1264)]
        [MinLength(1)]
//        [Required]
        public string Description { get; set; }
        
//        [Required]
        public decimal TimeEstimate { get; set; }
        
        public TaskType TaskType { get; set; }

        public TaskStatus TaskStatus { get; set; }
        
        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        public ICollection<UserTask> AppUsersInvolved { get; set; }

    }
}