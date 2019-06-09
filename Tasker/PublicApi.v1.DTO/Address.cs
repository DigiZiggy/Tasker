using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO
{
    public class Address
    {
        public int Id { get; set; }

        public string Country { get; set; }       

        public string City { get; set; }
        
        
        [MaxLength(64)]
        [MinLength(1)]
        public string Street { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string HouseNumber { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string UnitNumber { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string PostalCode { get; set; }
        
        public List<UserOnAddress> AppUsersOnAddress { get; set; }
        
        public List<TaskerTask> TasksOnAddress { get; set; }
    }
}
