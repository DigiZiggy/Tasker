using System;

namespace DTO
{
    public class IdentificationDTO
    {
        public int Id { get; set; }

        public string DocumentNumber { get; set; }
        
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

    }
}