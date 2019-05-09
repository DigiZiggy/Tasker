﻿using System.Collections.Generic;
using Domain;

namespace DAL.App.DTO
{
    public class AddressDTO
    {
        public int Id { get; set; }

        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string HouseNumber { get; set; }
        
        public string UnitNumber { get; set; }
        
        public string PostalCode { get; set; }
        
        public ICollection<UserOnAddress> AppUsersOnAddress { get; set; }
        
        public ICollection<TaskerTask> TasksOnAddress { get; set; }
    }
}
