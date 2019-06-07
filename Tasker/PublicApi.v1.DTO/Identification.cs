using System;
using PublicApi.v1.DTO.Enums;
using PublicApi.v1.DTO.Identity;

namespace PublicApi.v1.DTO
{
    public class Identification
    {
        public int Id { get; set; }
        
        public string DocNumber { get; set; }
        
        public IdentificationType IdentificationType { get; set; }
        
        public DateTime Start { get; set; }
        
        public DateTime? End { get; set; }
        
        public string Comment { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}