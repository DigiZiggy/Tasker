using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AppUser = BLL.App.DTO.Identity.AppUser;


namespace BLL.App.DTO
{
    public class HourlyRate
    {
        public int Id { get; set; }

        public decimal HourRate { get; set; }
        
        public DateTime Start { get; set; }
        
        public DateTime? End { get; set; }
        
        public ICollection<AppUser> AppUsers { get; set; }
    }
}