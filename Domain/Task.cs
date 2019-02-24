using System.ComponentModel.DataAnnotations;
using System.Security.Authentication.ExtendedProtection;

namespace Domain
{
    public class Task : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Description { get; set; }
        
        [Required]
        public int TimeEstimate { get; set; }

        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Address { get; set; }
        
        public int TaskTypeId { get; set; }
        public TaskType TaskType { get; set; }
    }
}