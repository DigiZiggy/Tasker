using System;

namespace DTO
{
    public class PriceDTO
    {
        public int Id { get; set; }
        
        public decimal Amount { get; set; }
        
        public DateTime Start { get; set; }

        public DateTime End { get; set; }
        
        public string Comment { get; set; }

    }
}