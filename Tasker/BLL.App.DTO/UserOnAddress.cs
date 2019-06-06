using System;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO.Identity;
using AppUser = BLL.App.DTO.Identity.AppUser;


namespace BLL.App.DTO
{
    public class UserOnAddress
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