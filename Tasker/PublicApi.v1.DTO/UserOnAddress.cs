using System;
using PublicApi.v1.DTO.Identity;

namespace PublicApi.v1.DTO
{
    public class UserOnAddress
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}