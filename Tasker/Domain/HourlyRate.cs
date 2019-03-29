using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class HourlyRate : BaseEntity
    {
//        [Required]
        public decimal HourRate { get; set; }
        
//        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int PriceListId { get; set; }
        public PriceList PriceList { get; set; }
    }
}