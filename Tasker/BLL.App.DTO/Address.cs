using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class Address
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
        
        
        [Display(Name = nameof(Street), ResourceType = typeof(Resources.Domain.Address))]
        public string Street { get; set; }
        
        
        [Display(Name = nameof(HouseNumber), ResourceType = typeof(Resources.Domain.Address))]
        public string HouseNumber { get; set; }
        
        
        [Display(Name = nameof(UnitNumber), ResourceType = typeof(Resources.Domain.Address))]
        public string UnitNumber { get; set; }
        
        
        [Display(Name = nameof(PostalCode), ResourceType = typeof(Resources.Domain.Address))]
        public string PostalCode { get; set; }
        
    }
}
