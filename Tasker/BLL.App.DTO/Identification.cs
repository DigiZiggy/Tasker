using System;
using System.ComponentModel.DataAnnotations;
using AppUser = BLL.App.DTO.Identity.AppUser;
using IdentificationType = BLL.App.DTO.Enums.IdentificationType;


namespace BLL.App.DTO
{
    public class Identification
    {
        public int Id { get; set; }
        
        [Display(Name = nameof(DocNumber), ResourceType = typeof(Resources.Domain.Identification))]
        public string DocNumber { get; set; }
        
        [Display(Name = nameof(IdentificationType), ResourceType = typeof(Resources.Domain.Identification))]
        public IdentificationType IdentificationType { get; set; }
        
        [Display(Name = nameof(Start), ResourceType = typeof(Resources.Domain.Identification))]
        public DateTime Start { get; set; }
        
        [Display(Name = nameof(End), ResourceType = typeof(Resources.Domain.Identification))]
        public DateTime? End { get; set; }
        
        [Display(Name = nameof(Comment), ResourceType = typeof(Resources.Domain.Identification))]
        public string Comment { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}