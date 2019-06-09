using System;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class UserTask : DomainEntity
    {
//        [Required]
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public int TaskId { get; set; }
        public TaskerTask TaskerTask { get; set; }

        public int TaskGiverId { get; set; } 
        public AppUser TaskGiver { get; set; }        
        
        public int TaskerId { get; set; }
        public AppUser Tasker { get; set; }   
        
    }
}