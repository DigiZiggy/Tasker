using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class UserOnTask : BaseEntity
    {
        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }

        [ForeignKey("TaskGiverId")]
        public int TaskGiverId { get; set; } 
        public User TaskGiver { get; set; }        
        
        [ForeignKey("TaskerId")]
        public int TaskerId { get; set; }
        public User Tasker { get; set; }        
    }
}