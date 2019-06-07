using System;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO.Identity;
using AppUser = BLL.App.DTO.Identity.AppUser;

namespace BLL.App.DTO
{
    public class UserTask
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }
        
        public DateTime? End { get; set; }
        
        public int TaskId { get; set; }
        public TaskerTask TaskerTask { get; set; }

        public int TaskGiverId { get; set; } 
        public Identity.AppUser TaskGiver { get; set; }        
        
        public int TaskerId { get; set; }
        public AppUser Tasker { get; set; }   
    }
}