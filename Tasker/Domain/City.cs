using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class City : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string Name { get; set; }
        public string Comment { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
        
    }
}