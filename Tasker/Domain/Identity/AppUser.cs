using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser : IdentityUser<int>, IBaseEntity, IDomainEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string FirstName { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string LastName { get; set; }   
        
        public string SelfDescription { get; set; }                
        
        public int? HourlyRateId { get; set; }
        public HourlyRate HourlyRate { get; set; }

        public ICollection<UserSkill> Skills { get; set; }
        
        [InverseProperty("TaskGiver")]
        public ICollection<UserTask> TasksCreated { get; set; }
        
        [InverseProperty("Tasker")]
        public ICollection<UserTask> TasksWorkedOn { get; set; }
        
        public ICollection<UserOnAddress> Addresses { get; set; }
                
        [InverseProperty("ReviewGiver")]
        public ICollection<Review> GivenReviews { get; set; }
        
        [InverseProperty("ReviewReceiver")]
        public ICollection<Review> ReceivedReviews { get; set; }
        
        public ICollection<Invoice> Invoices { get; set; }
        
        public ICollection<Identification> Identifications { get; set; }
       
    }
}