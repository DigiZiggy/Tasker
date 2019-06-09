using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.App.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }       
        public string LastName { get; set; }                
        
        public string SelfDescription { get; set; } 
        
        public string Email { get; set; }

        public int? HourlyRateId { get; set; }
        public HourlyRate HourlyRate { get; set; }
        
    }
}