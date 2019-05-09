using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class UserTaskCreateViewModel
    {
        public UserTask UserTask { get; set; }
        public SelectList TaskerSelectList { get; set; }
        public SelectList TaskGiverSelectList { get; set; }
    }
}