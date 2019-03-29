using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class IdentificationType : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}