using System;
using System.Collections.Generic;
using DAL.App.DTO.Identity;


namespace DAL.App.DTO
{
    public class HourlyRate
    {
        public int Id { get; set; }

        public decimal HourRate { get; set; }
        
        public DateTime Start { get; set; }
        
        public DateTime? End { get; set; }
        
    }
}