using System;
using System.ComponentModel.DataAnnotations;
using Domain.Identity;

namespace Domain
{
    public class Identification : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string DocumentNumber { get; set; }
        
        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Comment { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public int IdentificationTypeId { get; set; }
        public IdentificationType IdentificationType { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}