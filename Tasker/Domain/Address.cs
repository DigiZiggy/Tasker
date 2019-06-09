using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;

namespace Domain
{
    public class Address : DomainEntity
    {
        public string Country { get; set; }        
        public string City { get; set; }
                
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string Street { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string HouseNumber { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string UnitNumber { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string PostalCode { get; set; }
        
        public List<UserOnAddress> AppUsersOnAddress { get; set; }
        
        public List<TaskerTask> TasksOnAddress { get; set; }
        
    }
}