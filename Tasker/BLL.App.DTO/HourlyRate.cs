using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AppUser = BLL.App.DTO.Identity.AppUser;


namespace BLL.App.DTO
{
    public class HourlyRate
    {
        public int Id { get; set; }

        [Display(Name = nameof(HourRate), ResourceType = typeof(Resources.Domain.HourlyRate))]
        public decimal HourRate { get; set; }
        
        [Display(Name = nameof(Start), ResourceType = typeof(Resources.Domain.HourlyRate))]
        public DateTime Start { get; set; }
        
        [Display(Name = nameof(End), ResourceType = typeof(Resources.Domain.HourlyRate))]
        public DateTime? End { get; set; }
        
    }
}