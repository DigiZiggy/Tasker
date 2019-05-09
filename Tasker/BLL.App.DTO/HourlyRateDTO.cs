using System;
using System.Collections.Generic;
using Domain.Identity;

namespace DAL.App.DTO
{
    public class HourlyRateDTO
    {
        public int Id { get; set; }

        public decimal HourRate { get; set; }
        
        public DateTime Start { get; set; }
        
        public DateTime End { get; set; }
        
        public ICollection<AppUser> AppUsers { get; set; }
    }
}