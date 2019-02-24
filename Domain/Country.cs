using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Country : BaseEntity
    {
        [Required]
        public string CountryCode { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
    }
}