using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class UserOnAddress : BaseEntity
    {
        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}