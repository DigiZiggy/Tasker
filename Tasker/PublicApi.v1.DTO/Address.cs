﻿using System.Collections.Generic;

namespace PublicApi.v1.DTO
{
    public class Address
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string HouseNumber { get; set; }
        
        public string UnitNumber { get; set; }
        
        public string PostalCode { get; set; }
        
        public ICollection<UserOnAddress> AppUsersOnAddress { get; set; }
        
        public ICollection<TaskerTask> TasksOnAddress { get; set; }
    }
}
