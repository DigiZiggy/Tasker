using System;
using Domain;
using Domain.Identity;

namespace DAL.App.DTO
{
    public class UserOnAddressDTO
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }
        
        public DateTime End { get; set; }
        
        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}