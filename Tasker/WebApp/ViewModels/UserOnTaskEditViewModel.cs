using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class UserOnTaskEditViewModel
    {
        public UserOnTask UserOnTask { get; set; }
        public SelectList AppUserSelectList { get; set; }
        public SelectList TaskSelectList { get; set; }
        public SelectList TaskerSelectList { get; set; }
        public SelectList TaskGiverSelectList { get; set; }
    }
}