using PublicApi.v1.DTO.Identity;

namespace PublicApi.v1.DTO
{
    public class Review
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