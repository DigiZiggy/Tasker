using System.Collections.Generic;
using PublicApi.v1.DTO.Enums;

namespace PublicApi.v1.DTO
{
    public class TaskerTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public decimal TimeEstimate { get; set; }
        
        public TaskType TaskType { get; set; }

        public TaskStatus TaskStatus { get; set; }        
        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        public List<UserTask> AppUsersInvolved { get; set; }
    }
}