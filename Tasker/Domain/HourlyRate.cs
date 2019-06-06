using System;
using System.Collections.Generic;
using Contracts.DAL.Base;
using Domain.Base;
using Domain.Identity;

namespace Domain
{
    public class HourlyRate : BaseEntity, IDomainEntity
    {
//        [Required]
        public decimal HourRate { get; set; }
        
//        [Required]
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        
        public ICollection<AppUser> AppUsers { get; set; }

    }
}