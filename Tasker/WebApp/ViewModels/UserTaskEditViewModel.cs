using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserTask = BLL.App.DTO.UserTask;

namespace WebApp.ViewModels
{
    public class UserTaskEditViewModel
    {
        public UserTask UserTask { get; set; }
        public SelectList TaskerSelectList { get; set; }
        public SelectList TaskGiverSelectList { get; set; }
    }
}