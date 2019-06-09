using System.Collections.Generic;
using DAL.App.DTO.Enums;


namespace DAL.App.DTO
{
    public class TaskerTask
    {
        public int Id { get; set; }

        public string TaskName { get; set; }
        
        public string Description { get; set; }
        
        public decimal TimeEstimate { get; set; }
        
        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        public TaskType TaskType { get; set; }

        public TaskStatus TaskStatus { get; set; }
    }
}