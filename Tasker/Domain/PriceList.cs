using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class PriceList : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        
//        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}