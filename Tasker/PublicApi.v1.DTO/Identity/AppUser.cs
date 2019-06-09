using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PublicApi.v1.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string FirstName { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string LastName { get; set; }   

        public string SelfDescription { get; set; }   
        
        public string Email { get; set; }                
        
        public int? HourlyRateId { get; set; }
        public HourlyRate HourlyRate { get; set; }

        public List<UserSkill> Skills { get; set; }
        
        [InverseProperty("TaskGiver")]
        public List<UserTask> TasksCreated { get; set; }
        
        [InverseProperty("Tasker")]
        public List<UserTask> TasksWorkedOn { get; set; }
        
        public List<UserOnAddress> Addresses { get; set; }
                
        [InverseProperty("ReviewGiver")]
        public List<Review> GivenReviews { get; set; }
        
        [InverseProperty("ReviewReceiver")]
        public List<Review> ReceivedReviews { get; set; }
        
        public List<Invoice> Invoices { get; set; }
        
        public List<Identification> Identifications { get; set; }
    }
}