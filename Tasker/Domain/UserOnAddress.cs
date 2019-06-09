using System;
using Contracts.DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class UserOnAddress : DomainEntity
    {
//        [Required]
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }

}