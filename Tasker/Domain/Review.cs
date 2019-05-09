using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Domain.Identity;

namespace Domain
{
    public class Review : BaseEntity
    {
//        [Required]
        public int Rating { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string ReviewComment { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}