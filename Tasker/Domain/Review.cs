using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Domain.Identity;

namespace Domain
{
    public class Review : BaseEntity
    {
//        [Required]
        public int Rating { get; set; }
        
        [MaxLength(1264)]
        [MinLength(1)]
//        [Required]
        public string ReviewComment { get; set; }
              
        public int ReviewGiverId { get; set; } 
        public AppUser ReviewGiver { get; set; }        
        
        public int ReviewReceiverId { get; set; }
        public AppUser ReviewReceiver { get; set; }  
    }
}