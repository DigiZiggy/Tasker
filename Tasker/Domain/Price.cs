using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Price : BaseEntity
    {
        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Comment { get; set; }

        public int PriceListId { get; set; }
        public PriceList PriceList { get; set; }
    }
}