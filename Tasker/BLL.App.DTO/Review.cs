using System.ComponentModel.DataAnnotations;
using AppUser = BLL.App.DTO.Identity.AppUser;

namespace BLL.App.DTO
{
    public class Review
    {
        public int Id { get; set; }

        public int Rating { get; set; }
        
        public string ReviewComment { get; set; }
        
        public int ReviewGiverId { get; set; } 
        public Identity.AppUser ReviewGiver { get; set; }        
        
        public int ReviewReceiverId { get; set; }
        public AppUser ReviewReceiver { get; set; }  
    }
}