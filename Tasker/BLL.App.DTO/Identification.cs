using System;
using System.ComponentModel.DataAnnotations;
using AppUser = BLL.App.DTO.Identity.AppUser;
using IdentificationType = BLL.App.DTO.Enums.IdentificationType;


namespace BLL.App.DTO
{
    public class Identification
    {
        public int Id { get; set; }
        
        public string DocNumber { get; set; }
        
        public IdentificationType IdentificationType { get; set; }
        
        public DateTime Start { get; set; }
        
        public DateTime? End { get; set; }
        
        public string Comment { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}