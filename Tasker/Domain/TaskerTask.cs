using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Domain.Identity;

namespace Domain
{
    public class TaskerTask : DomainEntity
    {       
        [ForeignKey(nameof(TaskName))]
        public int TaskNameId { get; set; }
        public MultiLangString TaskName { get; set; }
        
        [ForeignKey(nameof(Description))]
        public int DescriptionId { get; set; }
        public MultiLangString Description { get; set; }
                
//        [Required]
        public decimal TimeEstimate { get; set; }
        
        public TaskType TaskType { get; set; }

        public TaskStatus TaskStatus { get; set; }
        
        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        public List<UserTask> AppUsersInvolved { get; set; }

    }
}