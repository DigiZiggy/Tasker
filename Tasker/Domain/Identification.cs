using System;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using Domain.Base;
using Domain.Enums;
using Domain.Identity;

namespace Domain
{
    public class Identification : BaseEntity, IDomainEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string DocNumber { get; set; }
        
        public IdentificationType IdentificationType { get; set; }
        
//        [Required]
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Comment { get; set; }
      
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}