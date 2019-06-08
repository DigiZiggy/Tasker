using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.App.DTO.Identity
{
    public class AppUser
    {
        public int Id { get; set; }
        
        [MaxLength(64,ErrorMessageResourceName = "ErrorMessageMaxLength" ,ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(FirstName), ResourceType = typeof(Resources.Domain.AppUser))]
        public string FirstName { get; set; }    
        
        [MaxLength(64,ErrorMessageResourceName = "ErrorMessageMaxLength" ,ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [MinLength(2, ErrorMessageResourceName = "ErrorMessageMinLength", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Domain.Common))]
        [Display(Name = nameof(LastName), ResourceType = typeof(Resources.Domain.AppUser))]
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
        public string FirstLastName => FirstName + " " + LastName;
    }
}