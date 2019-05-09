using Domain.Identity;

namespace DAL.App.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }

        public int Rating { get; set; }
        
        public string ReviewComment { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}