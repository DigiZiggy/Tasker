using System;
using System.Collections.Generic;
using Domain.Base;
using Domain.Identity;

namespace Domain
{
    public class HourlyRate : BaseEntity
    {
//        [Required]
        public decimal HourRate { get; set; }
        
//        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
        public ICollection<AppUser> AppUsers { get; set; }

    }
}