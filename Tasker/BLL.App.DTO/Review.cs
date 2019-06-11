using System.ComponentModel.DataAnnotations;
using AppUser = BLL.App.DTO.Identity.AppUser;

namespace BLL.App.DTO
{
    public class Review
    {
        public int Id { get; set; }

        [Display(Name = nameof(Rating), ResourceType = typeof(Resources.Domain.Review))]
        public int Rating { get; set; }
        
        [Display(Name = nameof(ReviewComment), ResourceType = typeof(Resources.Domain.Review))]
        public string ReviewComment { get; set; }
        
        public int ReviewGiverId { get; set; } 
        public AppUser ReviewGiver { get; set; }        
        
        public int ReviewReceiverId { get; set; }
        public AppUser ReviewReceiver { get; set; }  
    }
}