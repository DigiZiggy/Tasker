using Domain.Identity;

namespace DAL.App.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }

        public int Rating { get; set; }
        
        public string ReviewComment { get; set; }
        
        public int ReviewGiverId { get; set; } 
        public AppUser ReviewGiver { get; set; }        
        
        public int ReviewReceiverId { get; set; }
        public AppUser ReviewReceiver { get; set; }  
    }
}