using System;
using System.Collections.Generic;
using PublicApi.v1.DTO.Identity;

namespace PublicApi.v1.DTO
{
    public class HourlyRate
    {
        public int Id { get; set; }

        public decimal HourRate { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        
    }
}