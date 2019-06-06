using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using Domain.Base;

namespace Domain
{
    public class Address : BaseEntity, IDomainEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
        public string Country { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
//        [Required]
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
        
        public ICollection<UserOnAddress> AppUsersOnAddress { get; set; }
        
        public ICollection<TaskerTask> TasksOnAddress { get; set; }
        
    }
}