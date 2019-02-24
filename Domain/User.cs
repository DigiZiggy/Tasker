using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Domain
{
    public class User : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string FirstName { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string LastName { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Email { get; set; }
        
        [Required]
        public int Phone { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public int HourlyRateId { get; set; }
        public HourlyRate HourlyRate { get; set; }
    }
}