using System;
using System.Collections.Generic;
using Domain.Identity;

namespace Domain
{
    public class HourlyRate : DomainEntity
    {
//        [Required]
        public decimal HourRate { get; set; }
        
//        [Required]
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        
        public List<AppUser> AppUsers { get; set; }

    }
}