using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Address : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Street { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string District { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string PostalCode { get; set; }
        
        public int CityId { get; set; }
        public City City { get; set; }
    }
}