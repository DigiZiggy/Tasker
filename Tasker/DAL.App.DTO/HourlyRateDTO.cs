using System;

namespace DAL.App.DTO
{
    public class HourlyRateDTO
    {
        public int Id { get; set; }

        public decimal HourRate { get; set; }
        
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

    }
}