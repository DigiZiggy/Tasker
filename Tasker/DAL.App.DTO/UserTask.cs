using System;
using DAL.App.DTO.Identity;


namespace DAL.App.DTO
{
    public class UserTask
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }
        
        public DateTime? End { get; set; }
        
        public int TaskId { get; set; }
        public TaskerTask TaskerTask { get; set; }

        public int TaskGiverId { get; set; } 
        public AppUser TaskGiver { get; set; }        
        
        public int TaskerId { get; set; }
        public AppUser Tasker { get; set; }   
    }
}